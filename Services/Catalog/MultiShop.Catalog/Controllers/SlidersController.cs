using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SlidersController : ControllerBase
{
    private readonly IFeatureSliderService _featureSliderService;

    public SlidersController(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }

    
    [HttpGet]
    public async Task<IActionResult> SliderList()
    {
        List<ResultFeatureSliderDto> values = await _featureSliderService.GetAllSliderAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSliderById(string id)
    {
        GetByIdFeatureSliderDto value = await _featureSliderService.GetByIdSliderAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _featureSliderService.CreateSliderAsync(createFeatureSliderDto);
        return Ok("Success");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSlider(string id)
    {
        await _featureSliderService.DeleteSliderAsync(id);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSlider(UpdateFeatureSliderDto featureSliderDto)
    {
        await _featureSliderService.UpdateSliderAsync(featureSliderDto);
        return Ok("Success");
    }
}