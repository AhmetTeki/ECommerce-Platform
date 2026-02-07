using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent;

public class _FeaturesPartial : ViewComponent
{
    private readonly IFeatureServices _featureService;

    public _FeaturesPartial(IFeatureServices featureService)
    {
        _featureService = featureService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultFeatureDto> values = await _featureService.GetAllFeatureAsync();
        return View(values);
    }
}