using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _CategoriesPartial : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _CategoriesPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultCategoryDto> values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }
}