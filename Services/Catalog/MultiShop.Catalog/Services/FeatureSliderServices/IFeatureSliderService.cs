using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllSliderAsync();
    
    Task CreateSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    
    Task UpdateSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    
    Task DeleteSliderAsync(string id);
    
    Task<GetByIdFeatureSliderDto> GetByIdSliderAsync(string id);
    
    Task SliderChangeStatusTrue(string id);
    
    Task SliderChangeStatusFalse(string id);
}