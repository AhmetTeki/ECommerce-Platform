using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Brand")]
public class BrandController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BrandController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [Route("Index")]
    public async Task<IActionResult> Index()
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

    [HttpGet]
    [Route("CreateBrand")]
    public IActionResult CreateBrand()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateBrand")]
    public async Task<IActionResult> CreateBrand(CreateBrandDto brand)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(brand);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/Brands", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteBrand/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:7099/api/Brands/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateBrand/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Brands/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateBrandDto? values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("UpdateBrand/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto brand)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(brand);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/Brands/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        return View();
    }
}