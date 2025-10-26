using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.SpecialDiscountDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _DiscountPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DiscountPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/SpecialDiscount");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultSpecialDiscountDto>? values = JsonConvert.DeserializeObject<List<ResultSpecialDiscountDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}