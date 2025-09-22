using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FeaturesPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}