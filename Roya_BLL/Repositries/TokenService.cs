
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Roya_BLL.interFaces;
using Roya_DDL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Repositries
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateToken(User user, UserManager<User> userManager)
        {
            var authClime = new List<Claim>()
            {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.GivenName , user.UserName)
            };
            var authRole = await userManager.GetRolesAsync(user);
            foreach (var item in authRole)
            {
                authClime.Add(new Claim(ClaimTypes.Role, item.ToString()));
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var Token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"])),
                claims:authClime,
                signingCredentials:new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)



                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
