using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.Conventions;

namespace RepertoireManagementService.Infrastructure.Persistence;

internal static class ClassMaps
{
    public static void RegisterClassMaps()
    {
        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new StringIdStoredAsObjectIdConvention(),
            new IgnoreIfNullConvention(true),
            new IgnoreExtraElementsConvention(true)
        };

        ConventionRegistry.Register("convention", pack, t => true);

        if (!BsonClassMap.IsClassMapRegistered(typeof(CinemaEntity)))
        {
            BsonClassMap.RegisterClassMap<CinemaEntity>(x =>
            {
                x.AutoMap();
                x.MapMember(y => y.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(MovieEntity)))
        {
            BsonClassMap.RegisterClassMap<MovieEntity>(x =>
            {
                x.AutoMap();
                x.MapMember(y => y.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(RepertoireEntity)))
        {
            BsonClassMap.RegisterClassMap<RepertoireEntity>(x =>
            {
                x.AutoMap();
                x.MapMember(y => y.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(SeatEntity)))
        {
            BsonClassMap.RegisterClassMap<SeatEntity>(x =>
            {
                x.AutoMap();
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(ShowtimeEntity)))
        {
            BsonClassMap.RegisterClassMap<ShowtimeEntity>(x =>
            {
                x.AutoMap();
                x.MapMember(y => y.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(SittingEntity)))
        {
            BsonClassMap.RegisterClassMap<SittingEntity>(x =>
            {
                x.AutoMap();
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(UserEntity)))
        {
            BsonClassMap.RegisterClassMap<UserEntity>(x =>
            {
                x.AutoMap();
                x.MapMember(y => y.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
