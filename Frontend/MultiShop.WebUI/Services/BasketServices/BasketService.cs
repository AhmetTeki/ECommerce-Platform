using MultiShop.Dto.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync($"baskets");
        BasketTotalDto? values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
        return values;
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
    }

    public async Task DeleteBasket(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task AddBasketItem(BasketItemDto basketItemDto)
    {
        var values = await GetBasket();
        if (values != null)
        {
            if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                values = new BasketTotalDto();
                values.BasketItems.Add(basketItemDto);
            }
        }

        await SaveBasket(values);
    }

    public async Task<bool> RemoveBasketItem(string productId)
    {
        var values = await GetBasket();
        var deletedItem = values?.BasketItems.FirstOrDefault(x => x.ProductId == productId);
        values.BasketItems.Remove(deletedItem);
        await SaveBasket(values);
        return true;
    }
}