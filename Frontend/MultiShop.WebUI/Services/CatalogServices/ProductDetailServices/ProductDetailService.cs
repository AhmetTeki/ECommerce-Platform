using MultiShop.Dto.CatalogDtos.ProductDetailDtos;
using MultiShop.Dto.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

public class ProductDetailService : IProductDetailServices
{
    private readonly HttpClient _httpClient;

    public ProductDetailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultProductDetailDto>? values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
        return values;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _httpClient.DeleteAsync("productdetails?id=" + id);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails/" + id);
        GetByIdProductDetailDto? values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
        return values;
    }

    public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync($"productdetails/GetProductDetailByProductId/{id}/");
        GetByIdProductDetailDto? values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
        return values;
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("ProductImages");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultProductImageDto>? values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
        return values;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", createProductImageDto);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImages", updateProductImageDto);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _httpClient.DeleteAsync("ProductImages?id=" + id);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("ProductImages/" + id);
        GetByIdProductImageDto? values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        return values;
    }

    public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync($"ProductImages/ProductImagesByProductId/{id}/");
        GetByIdProductImageDto? values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        return values;
    }
}