using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.SliderDtos;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminSlider")]
public class AdminSliderController : Controller
{
    private readonly ISliderService _sliderService;

    public AdminSliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ResultSliderDto> values = await _sliderService.GetAllSliderAsync();
        return View(values);
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
        await _sliderService.CreateSliderAsync(slider);
        return RedirectToAction("Index", "AdminSlider", new { area = "Admin" });
    }

    [Route("DeleteSlider/{id}")]
    public async Task<IActionResult> DeleteSlider(string id)
    {
        await _sliderService.DeleteSliderAsync(id);
        return RedirectToAction("Index", "AdminSlider", new { area = "Admin" });
    }

    [Route("UpdateSlider/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateSlider(string id)
    {
        UpdateSliderDto value = await _sliderService.GetByIdSliderAsync(id);
        return View(value);
    }

    [Route("UpdateSlider/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateSlider(UpdateSliderDto slider)
    {
        await _sliderService.UpdateSliderAsync(slider);
        return RedirectToAction("Index", "AdminSlider", new { area = "Admin" });
    }
}