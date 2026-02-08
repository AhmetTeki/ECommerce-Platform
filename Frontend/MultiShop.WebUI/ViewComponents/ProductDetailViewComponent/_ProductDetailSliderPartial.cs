using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class _ProductDetailSliderPartial : ViewComponent
{
    private readonly IProductDetailServices _productDetailService;
    private readonly IProductService _productService;

    public _ProductDetailSliderPartial(IProductDetailServices productService, IProductService productService1)
    {
        _productDetailService = productService;
        _productService = productService1;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productService.GetByIdProductAsync(id);
        var valuesImage = await _productDetailService.GetByProductIdProductImageAsync(id);

        ProductDetailDto dto = new ProductDetailDto
        {
            Product = values,
            ProductImages = valuesImage
        };


        return View(dto);
    }
}