using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _OfferPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}