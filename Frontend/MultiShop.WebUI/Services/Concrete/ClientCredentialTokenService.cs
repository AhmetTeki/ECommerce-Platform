using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete;

public class ClientCredentialTokenService : IClientCredentialTokenService
{
    private readonly ServicesApiSettings _servicesApiSettings;
    private readonly HttpClient _httpClient;
    private readonly IClientAccessTokenCache _clientAccessTokenCache;
    private readonly ClientSettings _clientSettings;

    public ClientCredentialTokenService(IOptions<ServicesApiSettings> servicesApiSettings, HttpClient httpClient,
        IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
    {
        _servicesApiSettings = servicesApiSettings.Value;
        _httpClient = httpClient;
        _clientAccessTokenCache = clientAccessTokenCache;
        _clientSettings = clientSettings.Value;
    }

    public async Task<string> GetToken()
    {
        ClientAccessToken? token1 = await _clientAccessTokenCache.GetAsync("multishoptoken");

        if (token1 != null)
        {
            return token1.AccessToken;
        }

        DiscoveryDocumentResponse? discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _servicesApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        ClientCredentialsTokenRequest clientCredentialTokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
            ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
            Address = discoveryEndPoint.TokenEndpoint
        };

        TokenResponse? token2 = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
        await _clientAccessTokenCache.SetAsync("multishoptoken", token2.AccessToken, token2.ExpiresIn);
        return token2.AccessToken;
    }
}