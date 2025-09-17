using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCompanyController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompanyController(ICargoCompanyService cargoCompanyService)
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
    
    [HttpGet]
}