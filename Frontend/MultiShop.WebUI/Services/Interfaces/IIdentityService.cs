using MultiShop.Dto.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces;

public interface IIdentityService
{
    Task<bool> SignIn(SignUpDto dto);
}