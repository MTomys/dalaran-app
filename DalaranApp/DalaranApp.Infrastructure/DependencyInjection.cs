using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Infrastructure.Persistence.Repositories.Members;
using Microsoft.Extensions.DependencyInjection;

namespace DalaranApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IMemberRepository, InMemoryMemberRepository>();

        return services;
    }
}