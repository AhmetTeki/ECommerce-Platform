using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.BasketDtos;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IProductService _productService;

    public BasketController(IBasketService basketService, IProductService productService)
    {
        _basketService = basketService;
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }

    //[HttpPost]
    public async Task<IActionResult> AddBasketItem(string id)
    {
        UpdateProductDto values = await _productService.GetByIdProductAsync(id);
        var items = new BasketItemDto
        {
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            Price = values.ProductPrice,
            Quantity = 1,
            ProductImageUrl = values.ProductImageUrl
        };
        await _basketService.AddBasketItem(items);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveBasketItem(string id)
    {
        await _basketService.RemoveBasketItem(id);
        return RedirectToAction("Index");
    }
}