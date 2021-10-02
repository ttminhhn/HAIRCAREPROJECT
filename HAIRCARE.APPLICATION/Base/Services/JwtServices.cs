using HAIRCARE.APPLICATION.Base.Interfaces;
using HAIRCARE.APPLICATION.Base.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HAIRCARE.APPLICATION.Base.Services
{
    public class JwtServices : IJwtService
    {
        public string CreateAccessToken(JwtClaimSetting setting)
        {
            var key = Encoding.ASCII.GetBytes(JwtSetting.SECRET);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, setting.UserName),
                    new Claim(ClaimTypes.Email, setting.Email),
                    new Claim(ClaimTypes.NameIdentifier, setting.Id.ToString()),
                    new Claim(ClaimTypes.Role, setting.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(JwtSetting.SIGNIN_EXPIRE_DAY),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string CreateVerifyToken(JwtClaimSetting setting)
        {
            var key = Encoding.ASCII.GetBytes(JwtSetting.SECRET);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, setting.Email),
                    new Claim(ClaimTypes.NameIdentifier, setting.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(JwtSetting.VERIFY_TOKEN_EXPIRE_DAY),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
