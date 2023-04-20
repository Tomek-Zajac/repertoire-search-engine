using Domain.Interfaces;

namespace Domain.Entities;

public class ShowtimeEntity : IEntity
{
    public string Id { get; set; }
    public DateTime DateTime { get; set; }
}
