using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialDiscountServices;

public class SpecialDiscountService : ISpecialDiscountService
{
    private readonly IMongoCollection<SpecialDiscount> _discountCollection;
    private readonly IMapper _mapper;

    public SpecialDiscountService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _discountCollection = database.GetCollection<SpecialDiscount>(_databaseSettings.SpecialDiscountCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultSpecialDiscountDto>> GetAllSpecialDiscountAsync()
    {
        List<SpecialDiscount>? values= await _discountCollection.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultSpecialDiscountDto>>(values);
    }

    public async Task CreateSpecialDiscountAsync(CreateSpecialDiscountDto createSpecialDiscountDto)
    {
        SpecialDiscount? value= _mapper.Map<SpecialDiscount>(createSpecialDiscountDto);
        await _discountCollection.InsertOneAsync(value);
    }

    public async Task UpdateSpecialDiscountAsync(UpdateSpecialDiscountDto updateSpecialDiscountDto)
    {
        SpecialDiscount? values= _mapper.Map<SpecialDiscount>(updateSpecialDiscountDto);
        await _discountCollection.FindOneAndReplaceAsync(x=>x.SpecialDiscountId == updateSpecialDiscountDto.SpecialDiscountId, values);
    }

    public async Task DeleteSpecialDiscountAsync(string id)
    {
        await _discountCollection.DeleteOneAsync(x=>x.SpecialDiscountId == id);
    }

    public async Task<GetByIdSpecialDiscountDto> GetByIdSpecialDiscountAsync(string id)
    {
        SpecialDiscount? value= await _discountCollection.Find(x=>x.SpecialDiscountId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdSpecialDiscountDto>(value);
    }
}