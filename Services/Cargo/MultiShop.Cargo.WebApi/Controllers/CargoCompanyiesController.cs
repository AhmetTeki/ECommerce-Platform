using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompanyiesController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompanyiesController(ICargoCompanyService cargoCompanyService)
    {
        _cargoCompanyService = cargoCompanyService;
    }
    [HttpGet]
    public async Task<IActionResult> CargoCompanyList()
    {
        List<CargoCompany> values = await _cargoCompanyService.TGetAllAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCompany(CargoCompany cargoCompany)
    {
        await _cargoCompanyService.TInsertAsync(cargoCompany);
        return Ok("success");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoCompany(int id)
    {
        await _cargoCompanyService.TDeleteAsync(id);
        return Ok("success");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoCompanyById(int id)
    {
        CargoCompany values = await _cargoCompanyService.TGetByIdAsync(id);
        return Ok(values);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoCompany(CargoCompany cargoCompany)
    {
        await _cargoCompanyService.TUpdateAsync(cargoCompany);
        return Ok("success");
    }
}