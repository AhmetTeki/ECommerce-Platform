using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices;

public class AboutServices : IAboutServices
{
    private readonly IMongoCollection<About> _about;
    private readonly IMapper _mapper;

    public AboutServices(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _about = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        List<About>? values= await _about.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultAboutDto>>(values);
    }

    public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        About? value= _mapper.Map<About>(createAboutDto);
        await _about.InsertOneAsync(value);
    }

    public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        About? values= _mapper.Map<About>(updateAboutDto);
        await _about.FindOneAndReplaceAsync(x=>x.AboutId == updateAboutDto.AboutId, values);
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _about.DeleteOneAsync(x=>x.AboutId == id);
    }

    public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
    {
        About? value= await _about.Find(x=>x.AboutId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdAboutDto>(value);
    }
}