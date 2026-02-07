using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.AboutDto;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FooterPartial : ViewComponent
{
    private readonly IAboutService _aboutService;

    public _FooterPartial(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultAboutDto> values = await _aboutService.GetAllAboutAsync();
        return View(values);
    }
}