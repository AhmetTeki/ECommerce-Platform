using MultiShop.Dto.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices;

public class BrandService : IBrandService
{
    private readonly HttpClient _httpClient;

    public BrandService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("brands");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultBrandDto>? values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
        return values;
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands", createBrandDto);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands", updateBrandDto);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _httpClient.DeleteAsync("brands?id=" + id);
    }

    public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("brands/" + id);
        UpdateBrandDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
        return values;
    }
}