using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/OfferDiscount")]
public class OfferDiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OfferDiscountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
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

    [HttpGet]
    [Route("CreateOfferDiscount")]
    public IActionResult CreateOfferDiscount()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateOfferDiscount")]
    public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/OfferDiscounts", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteOfferDiscount/{id}")]
    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:7099/api/OfferDiscounts/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateOfferDiscount/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateOfferDiscount(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/OfferDiscounts/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateOfferDiscountDto? values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
            return View(values);
        }

        return View();
    }

    [Route("UpdateOfferDiscount/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(updateOfferDiscountDto);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/OfferDiscounts/", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        return View();
    }
}