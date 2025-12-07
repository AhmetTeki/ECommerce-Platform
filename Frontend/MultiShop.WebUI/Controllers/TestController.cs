using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}