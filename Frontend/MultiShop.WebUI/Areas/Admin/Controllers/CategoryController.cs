using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Category")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ResultCategoryDto> values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateCategory")]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
    {
        await _categoryService.CreateCategoryAsync(category);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    [Route("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    [Route("UpdateCategory/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        UpdateCategoryDto value = await _categoryService.GetByIdCategoryAsync(id);
        return View(value);
    }

    [Route("UpdateCategory/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
    {
        await _categoryService.UpdateCategoryAsync(category);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }
}