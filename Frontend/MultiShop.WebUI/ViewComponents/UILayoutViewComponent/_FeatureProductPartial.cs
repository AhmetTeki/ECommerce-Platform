using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FeatureProductPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}