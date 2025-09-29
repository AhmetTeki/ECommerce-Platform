using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class BasketController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}