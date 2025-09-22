using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _HeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}