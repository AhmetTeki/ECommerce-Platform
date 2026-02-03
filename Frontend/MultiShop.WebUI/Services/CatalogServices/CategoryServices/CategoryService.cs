using MultiShop.Dto.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("categories");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        return values;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _httpClient.DeleteAsync("categories?id=" + id);
    }

    public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("categories/" + id);
        UpdateCategoryDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
        return values;
    }
}