using MultiShop.Dto.CatalogDtos.AboutDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices;

public class AboutService : IAboutService
{
    private readonly HttpClient _httpClient;

    public AboutService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("abouts");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultAboutDto>? values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
        return values;
    }

    public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
    }

    public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _httpClient.DeleteAsync("abouts?id=" + id);
    }

    public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("abouts/" + id);
        UpdateAboutDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
        return values;
    }
}