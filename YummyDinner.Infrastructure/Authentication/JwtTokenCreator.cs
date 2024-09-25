using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YummyDinner.Application.Common.Contracts;


namespace YummyDinner.Infrastructure.Authentication
{

    /* A concrete implementation for creating a Json Web Token */
    public class JwtTokenCreator : IJwtTokenCreator
    {
        private  IConfiguration _config;
        public JwtTokenCreator(IConfiguration config) {

            this._config = config;

        }

        public string GenerateToken(Guid Id, string firstName, string lastName)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName)                       
            };

            var token = new JwtSecurityToken(
                issuer: "YummyDinner",
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}