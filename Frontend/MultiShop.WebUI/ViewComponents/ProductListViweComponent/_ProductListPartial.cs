using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViweComponent;

public class _ProductListPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}