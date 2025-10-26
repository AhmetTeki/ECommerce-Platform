using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Feature")]
public class FeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [Route("Index")]
    public async Task<IActionResult> Index()
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

    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto feature)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(feature);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/Features", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteFeature/{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:7099/api/Features/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateFeature/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Features/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateFeatureDto? values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("UpdateFeature/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto feature)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(feature);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/Features/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        return View();
    }
}