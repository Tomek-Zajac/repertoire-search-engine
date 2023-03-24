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

    [BsonElement("genre")]
    public string Genre { get; set; }

    [BsonElement("rating")]
    public double Rating { get; set; }

    [BsonElement("showtimes")]
    public List<DateTime> Showtimes { get; set; }
}
