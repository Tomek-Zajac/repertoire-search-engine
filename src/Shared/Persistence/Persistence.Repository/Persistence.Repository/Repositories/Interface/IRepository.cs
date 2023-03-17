using Domain.Interfaces;

namespace Persistence.Repository.Repositories.Interface;

public interface IRepository<T> where T : IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
