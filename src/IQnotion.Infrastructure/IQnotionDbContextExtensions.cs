using IQnotion.ApplicationCore.Interfaces;
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
                options.MigrationsAssembly("IQnotion.Presentation")
            )
        );

        services.AddScoped<IIQnotionNotionRepository, EFIQnotionRepository>();

        return services;
    }
}