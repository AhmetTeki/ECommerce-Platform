using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _NavbarPartial : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _NavbarPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultCategoryDto> categories = await _categoryService.GetAllCategoryAsync();
        return View(categories);
    }
}