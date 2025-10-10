using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.SliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/AdminSlider")]
public class AdminSliderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminSliderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Sliders");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultSliderDto>? values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]
    [Route("CreateSlider")]
    public IActionResult CreateSlider()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateSlider")]
    public async Task<IActionResult> CreateSlider(CreateSliderDto slider)
    {
        slider.Status = false;
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(slider);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/Sliders", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminSlider", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteSlider/{id}")]
    public async Task<IActionResult> DeleteSlider(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:7099/api/Sliders/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminSlider", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateSlider/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateSlider(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Sliders/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateSliderDto? values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("UpdateSlider/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateSlider(UpdateSliderDto slider)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(slider);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/Sliders/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminSlider", new { area = "Admin" });
        }

        return View();
    }
}