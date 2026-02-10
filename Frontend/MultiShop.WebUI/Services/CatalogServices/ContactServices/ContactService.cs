using MultiShop.Dto.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("contacts");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultContactDto>? values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
        return values;
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
    }

    public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
    }

    public async Task DeleteContactAsync(string id)
    {
        await _httpClient.DeleteAsync("contacts?id=" + id);
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("contacts/" + id);
        GetByIdContactDto? values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
        return values;
    }
}