using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.BasketViewComponent;

public class _BasketPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}