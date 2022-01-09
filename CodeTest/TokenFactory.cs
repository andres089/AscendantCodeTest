using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodeTest.Business.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers
{
    
    public sealed class TokenFactory 
    {
        private readonly IConfiguration configuration;

        public TokenFactory(IConfiguration config)
        {
            configuration = config;
        }

        public TokenResponse CreateToken(UserRequest user)
        {
            if (user is null)
            {
                return null;
            }

            string secretKey = configuration.GetValue<string>("Jwt:SecretKey");
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            DateTime expires = DateTime.UtcNow.AddMinutes(6);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponse
            {
                Expira = (int)(expires - DateTime.UtcNow).TotalMinutes,
                Type = "Bearer",
                Token = tokenHandler.WriteToken(token),
                Message = string.Empty
            };
        }
    }
}
