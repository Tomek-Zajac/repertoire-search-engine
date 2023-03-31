using Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities;

public class SeatEntity
{
    [BsonElement("row")]
    public string Row { get; set; }

    [BsonElement("seats")]
    public IEnumerable<string> Seats { get; set; } = new List<string>();
}
