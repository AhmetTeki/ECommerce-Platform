using MultiShop.Dto.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices;

public class FeatureService : IFeatureServices
{
    private readonly HttpClient _httpClient;

    public FeatureService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("features");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultFeatureDto>? values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
        return values;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _httpClient.DeleteAsync("features?id=" + id);
    }

    public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("features/" + id);
        UpdateFeatureDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();
        return values;
    }
}