using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.BasketViewComponent;

public class _BasketDiscountPartial : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}