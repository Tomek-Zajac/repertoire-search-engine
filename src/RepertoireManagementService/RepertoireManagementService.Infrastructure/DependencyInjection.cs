using Microsoft.Extensions.DependencyInjection;
using RepertoireManagementService.Application.Common.Interfaces;
using RepertoireManagementService.Infrastructure.Services;

namespace RepertoireManagementService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        //add httpClient
        services.AddHttpClient<IShowtimeService, ShowtimeService>((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://serpapi.com");
        });

        return services;
    }
}