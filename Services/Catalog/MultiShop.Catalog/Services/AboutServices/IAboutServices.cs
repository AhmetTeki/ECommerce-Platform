using MultiShop.Catalog.Dtos.AboutDto;

namespace MultiShop.Catalog.Services.AboutServices;

public interface IAboutServices
{
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    
    Task DeleteAboutAsync(string id);
    
    Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
}