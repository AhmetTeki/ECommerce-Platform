using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class ProductListController : Controller
{
    public IActionResult Index(string CategoryId)
    {
        ViewBag.CategoryId = CategoryId;
        return View();
    }

    public IActionResult ProductDetail()
    {
        return View();
    }
}