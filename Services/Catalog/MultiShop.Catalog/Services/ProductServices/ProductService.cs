using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService: IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }
    
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        List<Product>? values= await _productCollection.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        Product? value= _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        Product? values= _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId, values);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x=>x.ProductId == id);
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        Product? value= await _productCollection.Find(x=>x.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(value);
    }
}