using MultiShop.Dto.CatalogDtos.SliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices;

public interface ISliderService
{
    Task<List<ResultSliderDto>> GetAllSliderAsync();
    
    Task CreateSliderAsync(CreateSliderDto createFeatureSliderDto);
    
    Task UpdateSliderAsync(UpdateSliderDto updateFeatureSliderDto);
    
    Task DeleteSliderAsync(string id);
    
    Task<UpdateSliderDto> GetByIdSliderAsync(string id);
    
    Task SliderChangeStatusTrue(string id);
    
    Task SliderChangeStatusFalse(string id);
}