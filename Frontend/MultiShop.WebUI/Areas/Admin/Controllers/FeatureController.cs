using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Feature")]
public class FeatureController : Controller
{
    private readonly IFeatureServices _featureServices;

    public FeatureController(IFeatureServices featureServices)
    {
        _featureServices = featureServices;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ResultFeatureDto> values = await _featureServices.GetAllFeatureAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto feature)
    {
       await _featureServices.CreateFeatureAsync(feature);
       return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    [Route("DeleteFeature/{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureServices.DeleteFeatureAsync(id);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    [Route("UpdateFeature/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
       UpdateFeatureDto value = await _featureServices.GetByIdFeatureAsync(id);
       return View(value);
    }
    
    [Route("UpdateFeature/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto feature)
    {
        await _featureServices.UpdateFeatureAsync(feature);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }
}