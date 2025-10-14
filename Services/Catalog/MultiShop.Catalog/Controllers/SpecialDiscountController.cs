using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.SpecialDiscountDtos;
using MultiShop.Catalog.Services.SpecialDiscountServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SpecialDiscountController : ControllerBase
{
    private readonly ISpecialDiscountService _specialDiscountService;

    public SpecialDiscountController(ISpecialDiscountService specialDiscountService)
    {
        _specialDiscountService = specialDiscountService;
    }

    [HttpGet]
    public async Task<IActionResult> SpecialDiscountList()
    {
        List<ResultSpecialDiscountDto> values = await _specialDiscountService.GetAllSpecialDiscountAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialDiscountById(string id)
    {
        GetByIdSpecialDiscountDto value = await _specialDiscountService.GetByIdSpecialDiscountAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialDiscount(CreateSpecialDiscountDto createSpecialDiscountDto)
    {
        await _specialDiscountService.CreateSpecialDiscountAsync(createSpecialDiscountDto);
        return Ok("Success");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecialDiscount(string id)
    {
        await _specialDiscountService.DeleteSpecialDiscountAsync(id);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialDiscount(UpdateSpecialDiscountDto updateSpecialDiscountDto)
    {
        await _specialDiscountService.UpdateSpecialDiscountAsync(updateSpecialDiscountDto);
        return Ok("Success");
    }
}