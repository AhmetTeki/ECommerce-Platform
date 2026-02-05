using MultiShop.Dto.CatalogDtos.SliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices;

public class SliderService : ISliderService
{
    private readonly HttpClient _httpClient;

    public SliderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultSliderDto>> GetAllSliderAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("sliders");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultSliderDto>? values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
        return values;
    }

    public async Task CreateSliderAsync(CreateSliderDto createFeatureSliderDto)
    {
        await _httpClient.PostAsJsonAsync<CreateSliderDto>("sliders", createFeatureSliderDto);
    }

    public async Task UpdateSliderAsync(UpdateSliderDto updateFeatureSliderDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateSliderDto>("sliders", updateFeatureSliderDto);
    }

    public async Task DeleteSliderAsync(string id)
    {
        await _httpClient.DeleteAsync("sliders?id=" + id);
    }

    public async Task<UpdateSliderDto> GetByIdSliderAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("sliders/" + id);
        UpdateSliderDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateSliderDto>();
        return values;
    }

    public async Task SliderChangeStatusTrue(string id)
    {
        throw new NotImplementedException();
    }

    public async Task SliderChangeStatusFalse(string id)
    {
        throw new NotImplementedException();
    }
}