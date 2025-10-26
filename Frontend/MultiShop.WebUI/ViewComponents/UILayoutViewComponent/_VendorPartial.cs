using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _VendorPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _VendorPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Brands");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultBrandDto>? values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}