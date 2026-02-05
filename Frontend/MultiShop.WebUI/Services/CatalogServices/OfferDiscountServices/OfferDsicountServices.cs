using MultiShop.Dto.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

public class OfferDsicountServices : IOfferDsicountServices
{
    private readonly HttpClient _httpClient;

    public OfferDsicountServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("offerdiscounts");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultOfferDiscountDto>? values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
        return values;
    }

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto dto)
    {
        await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", dto);
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto dto)
    {
        await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("offerdiscounts", dto);
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
    }

    public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
        UpdateOfferDiscountDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
        return values;
    }
}