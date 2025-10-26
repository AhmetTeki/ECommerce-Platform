using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _CategoriesPartial :  ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CategoriesPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Categories");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}