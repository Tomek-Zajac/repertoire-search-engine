using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RepertoireManagementService.Application.Common.Interfaces;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Infrastructure.Persistence.Repositories;
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

        // Configure MongoDB connection
        services.AddSingleton<IMongoClient>(sp => 
        { 
            var configuration = sp.GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("MyMongoDB");
            return new MongoClient(connectionString);
        });

        // Register repository classes
        services.AddScoped<IRepository<CinemaEntity>, CinemaRepository>();

        return services;
    }
}