using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly IMongoCollection<Feature> _feature;
    private readonly IMapper _mapper;

    public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _feature = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
       List<Feature>? values= await _feature.Find(x=>true).ToListAsync();
       return _mapper.Map<List<ResultFeatureDto>>(values);
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        Feature? value= _mapper.Map<Feature>(createFeatureDto);
        await _feature.InsertOneAsync(value);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
       Feature? values= _mapper.Map<Feature>(updateFeatureDto);
       await _feature.FindOneAndReplaceAsync(x=>x.FeatureId == updateFeatureDto.FeatureId, values);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _feature.DeleteOneAsync(x=>x.FeatureId == id);
    }

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
    {
        var value= await _feature.Find(x=>x.FeatureId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdFeatureDto>(value);
    }
}