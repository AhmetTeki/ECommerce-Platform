using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.SliderDtos;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _SliderPartial : ViewComponent
{
    private readonly ISliderService _sliderService;

    public _SliderPartial(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [Route("Index")]
    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultSliderDto> values = await _sliderService.GetAllSliderAsync();
        return View(values);
    }
}