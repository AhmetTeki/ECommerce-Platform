using MultiShop.Dto.CatalogDtos.ProductImageDtos;

namespace MultiShop.Dto.CatalogDtos.ProductDtos;

public class ProductDetailDto
{
    public UpdateProductDto Product { get; set; }
    public GetByIdProductImageDto ProductImages { get; set; }
}