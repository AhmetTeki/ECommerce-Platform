using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers;

public class ProductListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index(string CategoryId)
    {
        ViewBag.CategoryId = CategoryId;
        return View();
    }

    public IActionResult ProductDetail(string id)
    {
        ViewBag.ProductId = id;
        return View();
    }

    [HttpGet]
    public PartialViewResult AddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(CreateCommentDto dto)
    {
        dto.Status = false;
        dto.ImageUrl = "test";
        dto.Rating = 1;
        dto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(dto);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:5168/api/Comments", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }

        return View();
    }
}