using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class _ProductDetailInformation : ViewComponent
{
    private readonly IProductDetailServices _productDetailServices;

    public _ProductDetailInformation(IProductDetailServices productDetailServices)
    {
        _productDetailServices = productDetailServices;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productDetailServices.GetByProductIdProductDetailAsync(id);
        return View(values);
    }
}