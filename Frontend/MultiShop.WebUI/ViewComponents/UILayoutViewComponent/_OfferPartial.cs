using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _OfferPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _OfferPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/OfferDiscounts");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultOfferDiscountDto>? values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}