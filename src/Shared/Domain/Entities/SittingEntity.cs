using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Interfaces;

namespace Domain.Entities;

public class SittingEntity
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("price")]
    public double Price { get; set; }

    [BsonElement("seats")]
    public IEnumerable<SeatEntity> Seats { get; set; }
}
