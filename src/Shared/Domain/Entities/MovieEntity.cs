using Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities;

public class MovieEntity : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("movieTitle")]
    public string MovieTitle { get; set; }

    [BsonElement("showtimes")]
    public IEnumerable<string> Showtimes { get; set; } = new List<string>();

    [BsonElement("imageUrl")]
    public string ImageUrl { get; set; }
}
