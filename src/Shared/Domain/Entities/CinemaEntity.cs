using Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities;

public class CinemaEntity : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("cinemaName")]
    public string CinemaName { get; set; }

    [BsonElement("address")]
    public string Address { get; set; }

    [BsonElement("city")]
    public string City { get; set; }

    [BsonElement("state")]
    public string State { get; set; }

    [BsonElement("zipCode")]
    public string ZipCode { get; set; }

    [BsonElement("repertoire")]
    public List<RepertoireEntity> Repertoire { get; set; } = new List<RepertoireEntity>();
}
