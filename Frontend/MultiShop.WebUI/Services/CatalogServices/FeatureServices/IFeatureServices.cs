using CreateFeatureDto = MultiShop.Dto.CatalogDtos.FeatureDtos.CreateFeatureDto;
using ResultFeatureDto = MultiShop.Dto.CatalogDtos.FeatureDtos.ResultFeatureDto;
using UpdateFeatureDto = MultiShop.Dto.CatalogDtos.FeatureDtos.UpdateFeatureDto;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices;

public interface IFeatureServices
{
    Task<List<ResultFeatureDto>> GetAllFeatureAsync();
    
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    
    Task DeleteFeatureAsync(string id);
    
    Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
}