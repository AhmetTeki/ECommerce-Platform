using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}