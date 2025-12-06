using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer.Dtos;
using Multishop.IdentityServer.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Multishop.IdentityServer.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            SignInResult result = await _userManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Succes");
            }
            else
            {
                return Ok("Failed");
            }
        }
    }
}