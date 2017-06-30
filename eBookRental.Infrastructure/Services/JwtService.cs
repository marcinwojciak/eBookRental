using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBookRental.Infrastructure.DTO;
using eBookRental.Infrastructure.Settings;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using eBookRental.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace eBookRental.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly AuthSettings _authSettings;

        public JwtService(AuthSettings authSettings)
        {
            _authSettings = authSettings;
        }

        public JwtDto CreateToken(string email, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_authSettings.TokenLifeTimeMinutes);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Key)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
               issuer: _authSettings.Issuer,
               claims: claims,
               expires: expires,
               notBefore: now,
               signingCredentials: signingCredentials
           );

           var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                TokenLifeTime = expires.ToTimestamp()
            };
        }
    }
}
