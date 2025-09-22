using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _CategoriesPartial :  ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}