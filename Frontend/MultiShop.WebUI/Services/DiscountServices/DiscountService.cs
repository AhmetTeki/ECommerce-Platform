using MultiShop.Dto.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;

    public DiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetDiscountCodeByCodeDto> GetDiscountCode(string code)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(("http://localhost:7215//api/Discount/GetCodeDetailByCodeAsync?code=" + code));
        GetDiscountCodeByCodeDto? values = await response.Content.ReadFromJsonAsync<GetDiscountCodeByCodeDto>();
        return values;
    }
}