using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService: IFeatureSliderService
{
    private readonly IMongoCollection<FeatureSlider> _featureSlider;
    private readonly IMapper _mapper;

    public FeatureSliderService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        _mapper = mapper;
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _featureSlider = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllSliderAsync()
    {
        List<FeatureSlider>? values= await _featureSlider.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultFeatureSliderDto>>(values);
    }

    public async Task CreateSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        FeatureSlider? value= _mapper.Map<FeatureSlider>(createFeatureSliderDto);
        await _featureSlider.InsertOneAsync(value);
    }

    public async Task UpdateSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        FeatureSlider? values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
        await _featureSlider.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, values);

    }

    public async Task DeleteSliderAsync(string id)
    {
        await _featureSlider.DeleteOneAsync(x=>x.FeatureSliderId == id);
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdSliderAsync(string id)
    {
        FeatureSlider? value= await _featureSlider.Find(x=>x.FeatureSliderId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdFeatureSliderDto>(value);
    }

    public async Task SliderChangeStatusTrue(string id)
    {
        throw new NotImplementedException();
    }

    public async Task SliderChangeStatusFalse(string id)
    {
        throw new NotImplementedException();
    }
}