using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.Dto.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers;

public class RegisterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegisterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
    {
        if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
        {
            HttpClient? client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(createRegisterDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost:5001/api/Register", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        return View();
    }
}