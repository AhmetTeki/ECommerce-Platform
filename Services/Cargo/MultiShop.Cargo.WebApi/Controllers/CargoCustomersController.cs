using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly ICargoCustomerService  _customerService;

    public CargoCustomersController(ICargoCustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> CargoCustomerList()
    {
        List<CargoCustomer> values = await _customerService.TGetAllAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCustomer(CargoCustomer cargoCustomer)
    {
        await _customerService.TInsertAsync(cargoCustomer);
        return Ok("success");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoCustomer(int id)
    {
        await _customerService.TDeleteAsync(id);
        return Ok("success");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoCustomerById(int id)
    {
        CargoCustomer values = await _customerService.TGetByIdAsync(id);
        return Ok(values);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoCustomer(CargoCustomer cargoCustomer)
    {
        await _customerService.TUpdateAsync(cargoCustomer);
        return Ok("success");
    }
}