using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViweComponent;

public class _ProductListPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _ProductListPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        List<ResultProductWithCategoryDto> values = await _productService.GetProductWithCategoryByCategoryIdAsync(id);
        return View(values);
    }
}