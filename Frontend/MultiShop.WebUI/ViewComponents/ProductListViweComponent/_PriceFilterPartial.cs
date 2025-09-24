using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViweComponent;

public class _PriceFilterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}