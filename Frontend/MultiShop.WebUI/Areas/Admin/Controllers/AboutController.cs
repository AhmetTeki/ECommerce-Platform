using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.AboutDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/About")]
public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Abouts");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultAboutDto>? values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]
    [Route("CreateAbout")]
    public IActionResult CreateAbout()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateAbout")]
    public async Task<IActionResult> CreateAbout(CreateAboutDto about)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(about);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/Abouts", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteAbout/{id}")]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:7099/api/Abouts/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateAbout/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateAbout(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Abouts/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateAboutDto? values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("UpdateAbout/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto about)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(about);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/Abouts/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        return View();
    }
}