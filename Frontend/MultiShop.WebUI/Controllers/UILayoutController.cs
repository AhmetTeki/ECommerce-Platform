using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class UILayoutController : Controller
{
    // GET
    public IActionResult _UILayout()
    {
        return View();
    }
}