using DalaranApp.Api.Common.Mappings;

namespace DalaranApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddSignalR();
        AddCorsForSignalR(services);
        return services;
    }

    private static void AddCorsForSignalR(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("ClientPermission", policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:5173")
                    .AllowCredentials();
            });
        });
    }
}