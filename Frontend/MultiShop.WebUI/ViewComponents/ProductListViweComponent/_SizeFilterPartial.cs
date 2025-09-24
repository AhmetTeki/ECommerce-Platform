using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViweComponent;

public class _SizeFilterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}