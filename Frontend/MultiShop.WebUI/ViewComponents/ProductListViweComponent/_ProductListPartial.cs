using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViweComponent;

public class _ProductListPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductListPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Products/ProductListWithCategoryByCategoryId?categoryId=" + id);
        
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultProductWithCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}