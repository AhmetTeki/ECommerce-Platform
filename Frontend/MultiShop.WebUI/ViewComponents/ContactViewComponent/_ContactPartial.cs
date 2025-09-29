using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponent;

public class _ContactPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}