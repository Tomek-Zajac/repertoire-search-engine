using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class RepertoireEntity : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("movieTitle")]
    public string MovieTitle { get; set; }

    [BsonElement("showtimes")]
    public List<string> Showtimes { get; set; } = new List<string>();

    [BsonElement("imageUrl")]
    public string ImageUrl { get; set; }
}
