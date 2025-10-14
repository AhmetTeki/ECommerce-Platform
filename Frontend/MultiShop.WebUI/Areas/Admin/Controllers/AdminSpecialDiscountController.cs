using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.SpecialDiscountDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/AdminSpecialDiscount")]
public class AdminSpecialDiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminSpecialDiscountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
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

    [HttpGet]
    [Route("CreateSpecialDiscount")]
    public IActionResult CreateSpecialDiscount()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateSpecialDiscount")]
    public async Task<IActionResult> CreateSpecialDiscount(CreateSpecialDiscountDto createSpecialDiscountDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createSpecialDiscountDto);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/SpecialDiscount", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminSpecialDiscount", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteSpecialDiscount/{id}")]
    public async Task<IActionResult> DeleteSpecialDiscount(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:7099/api/SpecialDiscount/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminSpecialDiscount", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateSpecialDiscount/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateSpecialDiscount(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/SpecialDiscount/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateSpecialDiscountDto? values = JsonConvert.DeserializeObject<UpdateSpecialDiscountDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("UpdateSpecialDiscount/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateSpecialDiscount(UpdateSpecialDiscountDto updateSpecialDiscountDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(updateSpecialDiscountDto);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/SpecialDiscount/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminSpecialDiscount", new { area = "Admin" });
        }

        return View();
    }
}