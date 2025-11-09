using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.Dto.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class _ProductDetailSliderPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailSliderPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpClient? client2 = _httpClientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync($"http://localhost:7099/api/Products/{id}");
        HttpResponseMessage response2 =
            await client2.GetAsync($"http://localhost:7099/api/ProductImages/ProductImagesByProductId?id=" + id);

        if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            string jsonDataImage = await response2.Content.ReadAsStringAsync();

            UpdateProductDto? values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            GetByIdProductImageDto valuesImage = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonDataImage);

            ProductDetailDto dto = new ProductDetailDto
            {
                Product = values,
                ProductImages = valuesImage
            };

            return View(dto);
        }

        return View();
    }
}