using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete;

public class UserService:IUserService
{
    private readonly HttpClient _httpClientFactory;

    public UserService(HttpClient httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<UserDetailViewModel> GetUserInfo()
    {
        return await _httpClientFactory.GetFromJsonAsync<UserDetailViewModel>("api/user/getuser");
    }
}