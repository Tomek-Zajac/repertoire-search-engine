using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Constants;

namespace Persistence.Mongo;

public static class MongoExtension
{
    private const string _customConventionsName = "Custom Conventions";

    public static IServiceCollection AddMongoDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        RegisterConventions();

        var connectionString = configuration.GetConnectionString(ConnectionStrings.MongoDb);
        var url = new MongoUrl(connectionString);
        var settings = MongoClientSettings.FromUrl(url);

        var client = new MongoClient(settings);
        var database = client.GetDatabase(url.DatabaseName);

        services.AddSingleton(client);
        services.AddSingleton(database);

        return services;
    }

    private static void RegisterConventions()
    {
        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new StringIdStoredAsObjectIdConvention(),
            new IgnoreIfNullConvention(true),
            new IgnoreExtraElementsConvention(true)
        };

        ConventionRegistry.Register(_customConventionsName, pack, t => true);
    }
}
