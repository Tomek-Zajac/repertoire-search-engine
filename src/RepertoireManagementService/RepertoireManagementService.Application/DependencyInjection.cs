using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using RepertoireManagementService.Application.Modules.Cinemas.Dtos;

namespace RepertoireManagementService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();

        //TypeAdapterConfig<CinemaEntity, CinemaDto>
        //    .NewConfig();

        return services;
    }
}
