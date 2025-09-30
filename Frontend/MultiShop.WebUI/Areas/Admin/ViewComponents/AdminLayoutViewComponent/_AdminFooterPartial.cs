using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponent;

public class _AdminFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}