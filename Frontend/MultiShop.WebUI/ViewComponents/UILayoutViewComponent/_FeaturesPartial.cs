using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FeaturesPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FeaturesPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Features");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultFeatureDto>? values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}