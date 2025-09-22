using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _TopbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}