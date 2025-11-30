using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto dto)
    {
        dto.IsRead = false;
        dto.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/Contacts", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }

        return View();
    }
}