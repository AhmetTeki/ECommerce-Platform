using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService:IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    private readonly IMapper _mapper;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }
    
    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        List<ProductDetail>? values= await _productDetailCollection.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        ProductDetail? value= _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        ProductDetail? values= _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x=>x.ProductDetailID == updateProductDetailDto.ProductDetailID, values);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x=>x.ProductDetailID == id);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        ProductDetail? value= await _productDetailCollection.Find(x=>x.ProductDetailID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(value);
    }
}