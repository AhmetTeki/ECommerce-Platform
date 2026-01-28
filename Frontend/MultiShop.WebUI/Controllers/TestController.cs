using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.Controllers;

public class TestController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ICategoryService _categoryService;

    public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
    {
        _httpClientFactory = httpClientFactory;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        string token = "";
        using (HttpClient httpClient = new HttpClient())
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5001/connect/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", "MultiShopVisitorId" },
                    { "client_secret", "multishopsecret" },
                    { "grant_type", "client_credentials" }
                })
            };

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject tokenResponse = JObject.Parse(content);
                    token = tokenResponse["access_token"].ToString();
                }
            }
        }

        HttpClient? client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:7099/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    public async Task<IActionResult> Test()
    {
        List<ResultCategoryDto> values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }
}