using CreateBrandDto = MultiShop.Dto.CatalogDtos.BrandDtos.CreateBrandDto;
using ResultBrandDto = MultiShop.Dto.CatalogDtos.BrandDtos.ResultBrandDto;
using UpdateBrandDto = MultiShop.Dto.CatalogDtos.BrandDtos.UpdateBrandDto;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandAsync();
    
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    
    Task DeleteBrandAsync(string id);
    
    Task<UpdateBrandDto> GetByIdBrandAsync(string id);
}