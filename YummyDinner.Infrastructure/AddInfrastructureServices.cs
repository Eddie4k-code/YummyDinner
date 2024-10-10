using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Application.Common.Contracts.Persistence;
using YummyDinner.Infrastructure.Authentication;
using YummyDinner.Infrastructure.Persistence;
using YummyDinner.Infrastructure.Services;

namespace YummyDinner.Infrastructure
{
    public static class AddInfrastructureServices
    {

        /* 
        * Extension method for IServiceCollection to register all infrastructure-specific services.
        * This method simplifies the service registration process by consolidating related services 
        */
            public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration config) {
                
                var JwtSettings = new JwtSettings();
                config.Bind("Jwt", JwtSettings);
                
                services.AddSingleton<IJwtTokenCreator, JwtTokenCreator>();
                services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.Configure<JwtSettings>(config.GetSection("Jwt"));
                services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Key))


                    });
                
                return services;
            }

    }
}