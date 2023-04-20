using Domain.Interfaces;

namespace Domain.Entities;

public class SittingEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public IEnumerable<SeatEntity> Seats { get; set; }
}
