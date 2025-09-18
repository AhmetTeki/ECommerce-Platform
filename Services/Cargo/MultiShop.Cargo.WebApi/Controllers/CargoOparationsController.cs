using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOparationsController : Controller
{
    private readonly ICargoOparationService  _cargoOparationService;

    public CargoOparationsController(ICargoOparationService cargoOparationService)
    {
        _cargoOparationService = cargoOparationService;
    }

    [HttpGet]
    public async Task<IActionResult> CargoOparationList()
    {
        List<CargoOparations> values = await _cargoOparationService.TGetAllAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoOparation(CargoOparations cargoOparations)
    {
        await _cargoOparationService.TInsertAsync(cargoOparations);
        return Ok("success");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoOparation(int id)
    {
        await _cargoOparationService.TDeleteAsync(id);
        return Ok("success");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoOparationById(int id)
    {
        CargoOparations values = await _cargoOparationService.TGetByIdAsync(id);
        return Ok(values);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoOparation(CargoOparations cargoOparations)
    {
        await _cargoOparationService.TUpdateAsync(cargoOparations);
        return Ok("success");
    }
}