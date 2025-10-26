using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }
    [HttpGet]
    public async Task<IActionResult> FeatureList()
    {
        List<ResultFeatureDto> values = await _featureService.GetAllFeatureAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureById(string id)
    {
        GetByIdFeatureDto value = await _featureService.GetByIdFeatureAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        await _featureService.CreateFeatureAsync(createFeatureDto);
        return Ok("Success");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        await _featureService.UpdateFeatureAsync(updateFeatureDto);
        return Ok("Success");
    }
}