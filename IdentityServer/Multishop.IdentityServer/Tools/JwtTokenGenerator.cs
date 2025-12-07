using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Multishop.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateTokeb(GetCheckUserViewModel user)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(user.Role))
                claims.Add(new Claim(ClaimTypes.Role, user.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            if (!string.IsNullOrWhiteSpace(user.UserName))
                claims.Add(new Claim("UserName", user.UserName));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime ExpireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudiance,
                claims: claims, notBefore: DateTime.UtcNow, expires: ExpireDate, signingCredentials: signInCredential);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), ExpireDate);
        }
    }
}