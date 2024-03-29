﻿using System.Text;
using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Infrastructure.Auth;
using DalaranApp.Infrastructure.Persistence.Repositories.Admins;
using DalaranApp.Infrastructure.Persistence.Repositories.Bajs;
using DalaranApp.Infrastructure.Persistence.Repositories.Members;
using DalaranApp.Infrastructure.Persistence.Repositories.Plebs;
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
        services.AddRepositories();
        services.AddAuth(configuration);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IMemberRepository, InMemoryMemberRepository>();
        services.AddSingleton<IPlebRepository, InMemoryPlebRepository>();
        services.AddSingleton<IAdminRepository, InMemoryAdminRepository>();
        services.AddSingleton<IBajRepository, InMemoryBajRepository>();
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtOptions = new JwtOptions();
        configuration.Bind("JWT", jwtOptions);

        services.AddSingleton(Options.Create(jwtOptions));
        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/hubs/chat")))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };
            });

        return services;
    }
}