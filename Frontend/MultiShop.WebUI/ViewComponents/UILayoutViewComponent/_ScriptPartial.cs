using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _ScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}