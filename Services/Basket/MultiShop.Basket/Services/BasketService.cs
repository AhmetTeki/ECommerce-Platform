using System.Text.Json;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using StackExchange.Redis;

namespace MultiShop.Basket.Services;

public class BasketService : IBasketServices
{
    private readonly RedisService  _redisService;

    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        RedisValue values = await _redisService.GetDb().StringGetAsync(userId);
        return  JsonSerializer.Deserialize<BasketTotalDto>(values);
      
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
    }

    public async Task DeleteBasket(string userId)
    {
         await _redisService.GetDb().KeyDeleteAsync(userId);
    }
}