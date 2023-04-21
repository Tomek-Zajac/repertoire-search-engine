using Domain.Interfaces;

namespace Domain.Entities;

public class RepertoireEntity : IEntity
{
    public string Id { get; set; }
    public IEnumerable<MovieEntity> Movies { get; set; } = new List<MovieEntity>();
    public IEnumerable<SittingEntity> Sittings { get; set; } = new List<SittingEntity>();
}
