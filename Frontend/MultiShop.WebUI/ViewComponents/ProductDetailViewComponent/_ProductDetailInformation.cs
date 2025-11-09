using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class _ProductDetailInformation : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailInformation(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/ProductDetails/GetProductDetailByProductId?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateProductDetailDto? values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
}