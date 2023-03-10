namespace Domain.Interfaces;

public interface IBaseEntity<TType>
{
    TType Id { get; set; }
}
