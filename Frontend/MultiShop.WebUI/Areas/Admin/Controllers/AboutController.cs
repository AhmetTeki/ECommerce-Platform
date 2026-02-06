using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.AboutDto;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/About")]
public class AboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ResultAboutDto> values = await _aboutService.GetAllAboutAsync();
        return View(values);
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
        await _aboutService.CreateAboutAsync(about);
        return RedirectToAction("Index", "About", new { area = "Admin" });
    }

    [Route("DeleteAbout/{id}")]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        await _aboutService.DeleteAboutAsync(id);
        return RedirectToAction("Index", "About", new { area = "Admin" });
    }

    [Route("UpdateAbout/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateAbout(string id)
    {
        UpdateAboutDto value = await _aboutService.GetByIdAboutAsync(id);
        return View(value);
    }

    [Route("UpdateAbout/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto about)
    {
        await _aboutService.UpdateAboutAsync(about);
        return RedirectToAction("Index", "About", new { area = "Admin" });
    }
}