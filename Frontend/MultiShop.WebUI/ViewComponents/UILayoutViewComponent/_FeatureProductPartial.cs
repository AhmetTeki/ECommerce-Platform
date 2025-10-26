using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FeatureProductPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FeatureProductPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Products");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultProductDto>? values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}