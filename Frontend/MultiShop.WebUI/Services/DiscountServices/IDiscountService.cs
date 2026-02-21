using MultiShop.Dto.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices;

public interface IDiscountService
{
    Task<GetDiscountCodeByCodeDto> GetDiscountCode(string code);
}