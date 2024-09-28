using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
                services.AddSingleton<IJwtTokenCreator, JwtTokenCreator>();
                services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.Configure<JwtSettings>(config.GetSection("Jwt"));

                
                return services;
            }

    }
}