using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _NavbarPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}