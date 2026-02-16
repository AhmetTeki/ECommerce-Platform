using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.BasketViewComponent;

public class _BasketPartial : ViewComponent
{
    private readonly IBasketService _basketService;

    public _BasketPartial(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var baskettTotal = await _basketService.GetBasket();
        var basketItems = baskettTotal.BasketItems;
        return View(basketItems);
    }
}