using System.Text;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Infrastructure.Auth;
using DalaranApp.Infrastructure.Persistence.Repositories.Members;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DalaranApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IMemberRepository, InMemoryMemberRepository>();
        services.AddAuth(configuration);

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtOptions = new JwtOptions();
        configuration.Bind("JWT", jwtOptions);

        services.AddSingleton(Options.Create(jwtOptions));
        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
            });

        return services;
    }
}