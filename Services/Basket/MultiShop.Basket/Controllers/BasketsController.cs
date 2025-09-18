using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok();
    }
}