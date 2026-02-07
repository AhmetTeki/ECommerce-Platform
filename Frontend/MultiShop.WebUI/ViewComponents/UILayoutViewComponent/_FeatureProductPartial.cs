using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FeatureProductPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _FeatureProductPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _productService.GetAllProductAsync();
        return View(values);
    }
}