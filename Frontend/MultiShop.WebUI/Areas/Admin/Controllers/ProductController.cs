using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Product")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
    {
        _httpClientFactory = httpClientFactory;
        _productService = productService;
        _categoryService = categoryService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ResultProductDto> values = await _productService.GetAllProductAsync();
        return View(values);
    }

    [Route("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Products/ProductListWithCategory");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultProductWithCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]
    [Route("CreateProduct")]
    public IActionResult CreateProduct()
    {
        var values = _categoryService.GetAllCategoryAsync();

        CreateProductDto model = new CreateProductDto
        {
            Categories = values.Result
        };
        return View(model);
    }

    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto product)
    {
        await _productService.CreateProductAsync(product);
        return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
    }

    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
    }

    [Route("UpdateProduct/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        Task<UpdateProductDto> productTask = _productService.GetByIdProductAsync(id);
        Task<List<ResultCategoryDto>> categoryTask = _categoryService.GetAllCategoryAsync();

        await Task.WhenAll(productTask, categoryTask);

        UpdateProductDto product = await productTask;
        List<ResultCategoryDto> categories = await categoryTask;

        product.Categories = categories;

        return View(product);
    }

    [Route("UpdateProduct/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto product)
    {
        await _productService.UpdateProductAsync(product);
        return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
    }
}