using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _OfferPartial : ViewComponent
{
    private readonly IOfferDsicountServices _offerDsicountServices;

    public _OfferPartial(IOfferDsicountServices offerDsicountServices)
    {
        _offerDsicountServices = offerDsicountServices;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
       var values = await _offerDsicountServices.GetAllOfferDiscountAsync();

       return View(values);
    }
}