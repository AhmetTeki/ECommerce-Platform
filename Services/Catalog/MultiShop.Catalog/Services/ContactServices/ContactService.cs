using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices;

public class ContactService : IContactService
{
    private readonly IMongoCollection<Contact> _contactCollection;
    private readonly IMapper _mapper;

    public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(_databaseSettings.DatabaseName);
        _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        List<Contact>? values = await _contactCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultContactDto>>(values);
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        Contact? value = _mapper.Map<Contact>(createContactDto);
        await _contactCollection.InsertOneAsync(value);
    }

    public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
    {
        Contact? values = _mapper.Map<Contact>(updateContactDto);
        await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values);
    }

    public async Task DeleteContactAsync(string id)
    {
        await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
    {
        Contact? value = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdContactDto>(value);
    }
}