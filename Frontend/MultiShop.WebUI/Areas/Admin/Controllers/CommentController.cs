using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Comment")]
public class CommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:5168/api/Comments");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultCommentDto>? values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [Route("DeleteComment/{id}")]
    public async Task<IActionResult> DeleteComment(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:5168/api/Comments/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateComment/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateComment(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:5168/api/Comments/" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateCommentDto? values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
            return View(values);
        }

        return View();
    }

    [Route("UpdateComment/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateComment(UpdateCommentDto commentDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(commentDto);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PutAsync("http://localhost:5168/api/Comments/", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        return View();
    }
}