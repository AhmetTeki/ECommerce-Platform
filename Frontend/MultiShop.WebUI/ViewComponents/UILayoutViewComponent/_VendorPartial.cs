using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _VendorPartial : ViewComponent
{
    private readonly IBrandService _brandService;

    public _VendorPartial(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultBrandDto> brands = await _brandService.GetAllBrandAsync();
        return View(brands);
    }
}