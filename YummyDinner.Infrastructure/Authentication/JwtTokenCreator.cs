using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Domain.Entities;


namespace YummyDinner.Infrastructure.Authentication
{

    /* A concrete implementation for creating a Json Web Token */
    public class JwtTokenCreator : IJwtTokenCreator
    {
        //private  IConfiguration _config;

        private readonly JwtSettings _jwtSettings;
        private IDateTimeProvider _dateTimeProvider;
        public JwtTokenCreator(/*IConfiguration config*/ IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider) {

            //this._config = config;
            this._jwtSettings = jwtSettings.Value;
            this._dateTimeProvider = dateTimeProvider;

        }

        public string GenerateToken(User user)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtSettings.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)                       
            };

            var token = new JwtSecurityToken(
                issuer: this._jwtSettings.Issuer,
                expires: this._dateTimeProvider.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}