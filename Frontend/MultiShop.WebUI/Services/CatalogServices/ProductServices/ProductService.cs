using MultiShop.Dto.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultProductDto>? values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        return values;
    }

    public async Task CreateProductAsync(CreateProductDto dto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDto>("products", dto);
    }

    public async Task UpdateProductAsync(UpdateProductDto dto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", dto);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _httpClient.DeleteAsync("products?id=" + id);
    }

    public async Task<UpdateProductDto> GetByIdProductAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/" + id);
        UpdateProductDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
        return values;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/productwithcategory");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultProductWithCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        return values;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId)
    {
        throw new NotImplementedException();
    }
}