using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brand;
    private readonly IMapper _mapper;

    public BrandService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _brand = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
       List<Brand>? values= await _brand.Find(x=>true).ToListAsync();
       return _mapper.Map<List<ResultBrandDto>>(values);
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        Brand? value= _mapper.Map<Brand>(createBrandDto);
        await _brand.InsertOneAsync(value);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        Brand? values= _mapper.Map<Brand>(updateBrandDto);
        await _brand.FindOneAndReplaceAsync(x=>x.BrandId == updateBrandDto.BrandId, values);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _brand.DeleteOneAsync(x=>x.BrandId == id);
    }

    public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
    {
        Brand? value= await _brand.Find(x=>x.BrandId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdBrandDto>(value);
    }
}