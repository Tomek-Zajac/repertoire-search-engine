using Domain.Entities;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Modules.Cinemas.Dtos;
using RepertoireManagementService.Infrastructure.Persistence.Repositories;

namespace RepertoireManagementService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {

        // Configure MongoDB connection
        services.AddSingleton<IMongoClient>(sp =>
        { 
            var configuration = sp.GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("MyMongoDB");
            return new MongoClient(connectionString);
        });

        // Register repository classes
        services.AddSingleton<IRepository<CinemaEntity>, CinemaRepository>();
        services.AddSingleton<IRepository<ShowtimeEntity>, ShowtimeRepository>();

        return services;
    }
}