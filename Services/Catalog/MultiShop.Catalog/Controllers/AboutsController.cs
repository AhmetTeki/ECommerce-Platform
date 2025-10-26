using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDto;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly IAboutServices _aboutServices;

    public AboutsController(IAboutServices aboutServices)
    {
        _aboutServices = aboutServices;
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        List<ResultAboutDto> values = await _aboutServices.GetAllAboutAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutById(string id)
    {
        GetByIdAboutDto value = await _aboutServices.GetByIdAboutAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        await _aboutServices.CreateAboutAsync(createAboutDto);
        return Ok("Success");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        await _aboutServices.DeleteAboutAsync(id);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        await _aboutServices.UpdateAboutAsync(updateAboutDto);
        return Ok("Success");
    }
}