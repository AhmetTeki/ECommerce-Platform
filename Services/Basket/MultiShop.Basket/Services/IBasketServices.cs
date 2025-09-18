using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services;

public interface IBasketServices
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
}