using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _DiscountPartial : ViewComponent
{
    private readonly IOfferDsicountServices _offerDsicountServices;

    public _DiscountPartial(IOfferDsicountServices offerDsicountServices)
    {
        _offerDsicountServices = offerDsicountServices;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultOfferDiscountDto> values = await _offerDsicountServices.GetAllOfferDiscountAsync();
        return View(values);
    }
}