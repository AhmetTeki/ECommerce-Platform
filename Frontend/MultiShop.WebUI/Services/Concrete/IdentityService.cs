using System.Security.Claims;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.Dto.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ClientSettings _clientSettings;

    public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _clientSettings = clientSettings.Value;
    }

    public async Task<bool> SignIn(SignUpDto dto)
    {
        DiscoveryDocumentResponse? discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = "http://localhost:7099",
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });
        PasswordTokenRequest passwordTokenRequest = new PasswordTokenRequest
        {
            ClientId = _clientSettings.MultiShopManagerClient.ClientId,
            ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
            UserName = dto.UserName,
            Password = dto.Password,
            Address = discoveryEndPoint.TokenEndpoint
        };

        TokenResponse? token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

        UserInfoRequest userInfoRequest = new UserInfoRequest
        {
            Token = token.AccessToken,
            Address = discoveryEndPoint.UserInfoEndpoint
        };
        
        UserInfoResponse userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);
        
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims,CookieAuthenticationDefaults.AuthenticationScheme,"name", "role");

        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        AuthenticationProperties authenticationProperties = new AuthenticationProperties();
        authenticationProperties.StoreTokens(new List<AuthenticationToken>()
        {
            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.AccessToken,
                Value = token.AccessToken
            },
            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.RefreshToken,
                Value = token.RefreshToken
            },
            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.ExpiresIn,
                Value = DateTime.Now.AddMinutes(token.ExpiresIn).ToString()
            }
        });
        authenticationProperties.IsPersistent=true;
        
    }
}