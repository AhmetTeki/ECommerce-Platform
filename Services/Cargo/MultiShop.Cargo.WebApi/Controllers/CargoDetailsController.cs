using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : Controller
{
    private readonly ICargoDetailService  _cargoDetailService;

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> CargoDetailList()
    {
        List<CargoDetail> values = await _cargoDetailService.TGetAllAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoDetail(CargoDetail cargoDetail)
    {
        await _cargoDetailService.TInsertAsync(cargoDetail);
        return Ok("success");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoDetail(int id)
    {
        await _cargoDetailService.TDeleteAsync(id);
        return Ok("success");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoDetailById(int id)
    {
        CargoDetail values = await _cargoDetailService.TGetByIdAsync(id);
        return Ok(values);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoDetail(CargoDetail cargoDetail)
    {
        await _cargoDetailService.TUpdateAsync(cargoDetail);
        return Ok("success");
    }
}