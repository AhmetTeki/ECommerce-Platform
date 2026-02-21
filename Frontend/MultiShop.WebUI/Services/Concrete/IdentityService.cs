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
    private readonly ServicesApiSettings _servicesApiSettings;

    public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings,
        IOptions<ServicesApiSettings> servicesApiSettings)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _servicesApiSettings = servicesApiSettings.Value;
        _clientSettings = clientSettings.Value;
    }

    public async Task<bool> SignIn(SignUpDto dto)
    {
        DiscoveryDocumentResponse? discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _servicesApiSettings.IdentityServerUrl,
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
            Address = discoveryEndPoint.TokenEndpoint,
            Scope = "offline_access openid profile email BasketFullPermission CatalogFullPermission DiscountFullPermission CommentFullPermission PaymentFullPermission OcelotFullPermission IdentityServerApi"
        };

        TokenResponse? token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
        
        // Geçici debug için ekle
        Console.WriteLine("ACCESS TOKEN: " + token.AccessToken);
        Console.WriteLine("REFRESH TOKEN: " + token.RefreshToken);

        UserInfoRequest userInfoRequest = new UserInfoRequest
        {
            Token = token.AccessToken,
            Address = discoveryEndPoint.UserInfoEndpoint
        };

        UserInfoResponse userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

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
        authenticationProperties.IsPersistent = true;
        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
            authenticationProperties);
        return true;
    }

    public async Task<bool> GetRefreshToken()
    {
        DiscoveryDocumentResponse? discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _servicesApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy { RequireHttps = false }
        });

        string? refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

        if (string.IsNullOrEmpty(refreshToken))
            return false;

        RefreshTokenRequest refreshTokenRequest = new()
        {
            ClientId = _clientSettings.MultiShopManagerClient.ClientId,
            ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
            RefreshToken = refreshToken,
            Address = discoveryEndPoint.TokenEndpoint
        };

        TokenResponse? token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

        if (token.IsError)
            return false;

        var authenticationTokens = new List<AuthenticationToken>
        {
            new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = token.AccessToken },
            new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = token.RefreshToken },
            new AuthenticationToken { Name = OpenIdConnectParameterNames.ExpiresIn, Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString() }
        };

        AuthenticateResult result = await _httpContextAccessor.HttpContext.AuthenticateAsync();
        AuthenticationProperties? properties = result.Properties;

        if (properties != null && result.Principal != null)
        {
            properties.StoreTokens(authenticationTokens);
            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                result.Principal,
                properties);
        }

        return true;
    }
}