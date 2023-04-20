using Domain.Interfaces;
namespace Domain.Entities;

public class MovieEntity : IEntity
{
    public string Id { get; set; }
    public string MovieTitle { get; set; }
    public IEnumerable<string> Showtimes { get; set; } = new List<string>();
    public string ImageUrl { get; set; }
}
