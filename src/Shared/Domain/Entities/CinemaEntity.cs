using Domain.Interfaces;

namespace Domain.Entities;

public class CinemaEntity : IEntity
{
    public string Id { get; set; }
    public string CinemaName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public IEnumerable<RepertoireEntity> Repertoire { get; set; } = new List<RepertoireEntity>();
}
