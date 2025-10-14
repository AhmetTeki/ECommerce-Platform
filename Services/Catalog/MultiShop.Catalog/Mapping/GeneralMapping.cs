using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialDiscountDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        //Category 
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
        //Product
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();
        CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
        //Product Detail
        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
        //Product Image
        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
        //Feature Slider
        CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();
        //Special Discount
        CreateMap<SpecialDiscount, ResultSpecialDiscountDto>().ReverseMap();
        CreateMap<SpecialDiscount, CreateSpecialDiscountDto>().ReverseMap();
        CreateMap<SpecialDiscount, UpdateSpecialDiscountDto>().ReverseMap();
        CreateMap<SpecialDiscount, GetByIdSpecialDiscountDto>().ReverseMap();
    }
}