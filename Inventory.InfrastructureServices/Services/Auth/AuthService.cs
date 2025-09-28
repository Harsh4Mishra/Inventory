using Inventory.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory.InfrastructureServices.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Claim[] claimsIdentity)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Key"]);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"])), SecurityAlgorithms.HmacSha256);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = claimsIdentity,
            //    Expires = DateTime.UtcNow.AddHours(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            //    Issuer = _configuration["JwtConfig:Issuer"],
            //    Audience = _configuration["JwtConfig:Audience"]
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            var token = new JwtSecurityToken(
                _configuration["JwtConfig:Issuer"],
                _configuration["JwtConfig:Audience"]
                , claimsIdentity,
                null,
                DateTime.Now.AddHours(2),
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
            //return tokenHandler.WriteToken(token);
        }
    }
}
