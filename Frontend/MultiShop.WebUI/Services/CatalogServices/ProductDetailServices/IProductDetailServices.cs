using MultiShop.Dto.CatalogDtos.ProductDetailDtos;
using MultiShop.Dto.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

public interface IProductDetailServices
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();

    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);

    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

    Task DeleteProductDetailAsync(string id);

    Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);

    Task<List<ResultProductImageDto>> GetAllProductImageAsync();

    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);

    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);

    Task DeleteProductImageAsync(string id);

    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
}