using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IQnotion.ApplicationCore;

public static class IQnotionCoreRxtensions
{
    public static IServiceCollection ConfigureIQnotionCore(this IServiceCollection services)
    {
        services.AddScoped<IIQnotionNotionService, IQnotionNotionService>();
        
        return services;
    }
}