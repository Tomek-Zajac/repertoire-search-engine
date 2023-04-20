using Domain.Interfaces;

namespace Domain.Entities;

public class SeatEntity
{
    public string Row { get; set; }
    public IEnumerable<string> Seats { get; set; } = new List<string>();
}
