using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class _ProductDetailInformation : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}