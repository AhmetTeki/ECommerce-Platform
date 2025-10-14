using MultiShop.Catalog.Dtos.SpecialDiscountDtos;

namespace MultiShop.Catalog.Services.SpecialDiscountServices;

public interface ISpecialDiscountService
{
    Task<List<ResultSpecialDiscountDto>> GetAllSpecialDiscountAsync();

    Task CreateSpecialDiscountAsync(CreateSpecialDiscountDto createSpecialDiscountDto);

    Task UpdateSpecialDiscountAsync(UpdateSpecialDiscountDto updateSpecialDiscountDto);

    Task DeleteSpecialDiscountAsync(string id);

    Task<GetByIdSpecialDiscountDto> GetByIdSpecialDiscountAsync(string id);
}