using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer.Dtos;
using Multishop.IdentityServer.Models;
using Multishop.IdentityServer.Tools;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Multishop.IdentityServer.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _userManager;
        private readonly UserManager<ApplicationUser> _user;

        public LoginController(SignInManager<ApplicationUser> userManager, UserManager<ApplicationUser> user)
        {
            _userManager = userManager;
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            SignInResult result = await _userManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
            var user = await _user.FindByNameAsync(userLoginDto.UserName);
            if (result.Succeeded)
            {
                GetCheckUserViewModel model = new GetCheckUserViewModel();
                model.UserName = userLoginDto.UserName;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateTokeb(model);
                return Ok(token);
            }
            else
            {
                return Ok("Failed");
            }
        }
    }
}