using DalaranApp.Api.Common.Mappings;

namespace DalaranApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddSignalR();
        return services;
    }
}