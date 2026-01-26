using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Interfaces;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MultiShop.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly IIdentityService _identityService;

    public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _identityService = identityService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string content = JsonConvert.SerializeObject(createLoginDto);

        StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:5001/api/Login", stringContent);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (token != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var tokenHandler = handler.ReadJwtToken(token.Token);
                var claims = tokenHandler.Claims.ToList();

                claims.Add(new Claim("multishoptoken", token.Token));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                AuthenticationProperties authProps = new AuthenticationProperties()
                {
                    ExpiresUtc = token.ExpireDate,
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                // var id = _loginService.GetUserId;

                return RedirectToAction("Index", "Default");
            }
        }

        return View();
    }
    
    // public IActionResult SignUp()
    // {
    //     return View();
    // }
    //[HttpPost]
    public async Task<IActionResult> SignUp(SignUpDto signUpDto)
    {
        signUpDto.UserName = "Ahmet";
        signUpDto.Password = "Ahmet02340.";
        await _identityService.SignIn(signUpDto);
        return RedirectToAction("Index", "User");
    }
    
}