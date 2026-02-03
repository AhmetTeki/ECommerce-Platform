using MultiShop.Dto.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();

    Task CreateProductAsync(CreateProductDto dto);

    Task UpdateProductAsync(UpdateProductDto dto);

    Task DeleteProductAsync(string id);

    Task<UpdateProductDto> GetByIdProductAsync(string id);
    Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync();

    Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId);
}