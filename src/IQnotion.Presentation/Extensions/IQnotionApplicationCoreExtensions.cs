using System.Text;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;
using IQnotion.ApplicationCore.Options;
using IQnotion.ApplicationCore.Services;
using IQnotion.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace IQnotion.Presentation.Extensions;

public static class IQnotionDbContextExtensions
{
    public static IServiceCollection ConfigureIQnotionApplicationCore(this IServiceCollection services)
    {
        services.AddScoped<IQnotionServices>();
        services.AddScoped<IIQnotionNotionService, IQnotionNotionService>();
        services.AddScoped<IIQnotionAuthorizationService, IQnotionAuthorizationService>();

        services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<IQnotionDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit           = true;
            options.Password.RequireLowercase       = false;
            options.Password.RequireUppercase       = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength         = 10;
            options.User.RequireUniqueEmail         = true;
        });

        return services;
    }

    public static IServiceCollection ConfigureIQnotionJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = Environment.GetEnvironmentVariable("SECRET") ?? throw new ArgumentNullException("SECRET");

        services.Configure<IQnotionAuthorizationOptions>(configuration.GetSection("JwtSettings"));

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer           = true,
                ValidateAudience         = true,
                ValidateLifetime         = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer              = configuration["JwtSettings:ValidIssuer"],
                ValidAudience            = configuration["JwtSettings:ValidAudience"],
                IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
        });

        return services;
    }
}
