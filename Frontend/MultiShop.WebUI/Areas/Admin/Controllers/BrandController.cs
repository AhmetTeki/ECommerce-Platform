using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Brand")]
public class BrandController : Controller
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ResultBrandDto> values = await _brandService.GetAllBrandAsync();
        return View(values);
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
        await _brandService.CreateBrandAsync(brand);
        return RedirectToAction("Index", "Brand", new { area = "Admin" });
    }

    [Route("DeleteBrand/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);
        return RedirectToAction("Index", "Brand", new { area = "Admin" });
    }

    [Route("UpdateBrand/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        UpdateBrandDto value = await _brandService.GetByIdBrandAsync(id);
        return View(value);
    }

    [Route("UpdateBrand/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto brand)
    {
        await _brandService.UpdateBrandAsync(brand);
        return RedirectToAction("Index", "Brand", new { area = "Admin" });
    }
}