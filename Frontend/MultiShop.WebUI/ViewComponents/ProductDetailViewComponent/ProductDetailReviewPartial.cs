using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class ProductDetailReviewPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductDetailReviewPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:5168/api/Comments/CommentListByProductId?id=" + productId);

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultCommentDto>? values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return View(values);
        }

        return View();
    }
    
}