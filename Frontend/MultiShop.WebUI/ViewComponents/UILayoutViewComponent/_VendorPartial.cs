using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _VendorPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}