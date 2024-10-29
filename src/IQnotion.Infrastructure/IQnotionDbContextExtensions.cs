using IQnotion.ApplicationCore.Interfaces;
using IQnotion.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IQnotion.Infrastructure;

public static class IQnotionDbContextExtensions
{
    public static IServiceCollection ConfigureIQnotionDbContext(this IServiceCollection services, IConfiguration config)
    {
        string connection = config.GetConnectionString("IQnotionDbContext") ?? throw new Exception("IQnotionDbContext configuration is required.");

        services.AddDbContext<IQnotionDbContext>(opt => 
            opt.UseNpgsql(connection, options => 
                options.MigrationsAssembly("IQnotion.Infrastructure")
            )
        );

        services.AddScoped<IQnotionDbSeed>();
        services.AddScoped<IIQnotionUnitOfWork, EFIQnotionUnitOfWork>();
        services.AddScoped<IIQnotionNotionRepository, EFIQnotionRepository>();
        services.AddScoped<IIQnotionUserNotionRepository, EFIQnotionUserNotionRepository>();

        return services;
    }
}