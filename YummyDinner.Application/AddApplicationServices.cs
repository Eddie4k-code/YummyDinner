using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YummyDinner.Application.Services.Authentication;



/* 
 * Extension method for IServiceCollection to register all application-specific services.
 * This method simplifies the service registration process by consolidating related services 
*/
public static class AddApplicationServices {
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services) {
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}