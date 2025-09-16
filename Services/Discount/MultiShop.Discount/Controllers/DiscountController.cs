using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> DiscountCouponList()
    {
        List<ResultCouponDto> values =await _discountService.GetAllCouponsAsync();
        return Ok(values);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        GetByIdCouponDto values =await _discountService.GetByIdCouponAsync(id);
        return Ok(values);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto dto)
    {
        await _discountService.CreateCouponAsync(dto);
        return Ok("success");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteCouponAsync(id);
        return Ok("success");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto dto)
    {
        await _discountService.UpdateCouponAsync(dto);
        return Ok("success"); 
    }
}