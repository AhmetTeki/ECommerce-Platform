using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]

public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        List<ResultProductDto> values =await _productService.GetAllProductAsync();
        return Ok(values);
    }
    [HttpGet("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        List<ResultProductWithCategoryDto> values =await _productService.GetProductWithCategoryAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        GetByIdProductDto value = await _productService.GetByIdProductAsync(id);
        return Ok(value);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _productService.CreateProductAsync(createProductDto);
        return Ok("Success");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok("Success");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProductAsync(updateProductDto);
        return Ok("Success");  
    }
    
    [HttpGet("ProductListWithCategoryByCategoryId")]
    public async Task<IActionResult> ProductListWithCategoryByCategoryId(string categoryId)
    {
        List<ResultProductWithCategoryDto> values =await _productService.GetProductWithCategoryByCategoryIdAsync(categoryId);
        return Ok(values);
    }
}