using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<ProductImage> _productImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        List<ProductImage>? values = await _productImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        ProductImage? value = _mapper.Map<ProductImage>(createProductImageDto);
        await _productImageCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        ProductImage? values = _mapper.Map<ProductImage>(updateProductImageDto);
        await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        ProductImage? value = await _productImageCollection.Find(x => x.ProductImageID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(value);
    }

    public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
    {
        ProductImage values = await _productImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(values);
    }
}