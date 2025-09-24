using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViweComponent;

public class _ColorFilterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}