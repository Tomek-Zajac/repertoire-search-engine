using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class RepertoireEntity : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("movies")]
    public IEnumerable<MovieEntity> Movies { get; set; } = new List<MovieEntity>();

    [BsonElement("sittings")]
    public IEnumerable<SittingEntity> Sittings { get; set; } = new List<SittingEntity>();
}
