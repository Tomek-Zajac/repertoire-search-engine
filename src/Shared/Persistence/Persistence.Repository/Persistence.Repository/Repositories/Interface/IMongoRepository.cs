using Domain.Interfaces;
using System.Linq.Expressions;

namespace Persistence.Repository.Repositories.Interface;

public interface IMongoRepository<T> where T : IEntity
{
    IQueryable<T> AsQueryable();

    IEnumerable<T> FilterBy(
        Expression<Func<T, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<T, bool>> filterExpression,
        Expression<Func<T, TProjected>> projectionExpression);

    T FindOne(Expression<Func<T, bool>> filterExpression);

    Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

    T FindById(string id);

    Task<T> FindByIdAsync(string id);

    void InsertOne(T document);

    Task InsertOneAsync(T document);

    void InsertMany(ICollection<T> documents);

    Task InsertManyAsync(ICollection<T> documents);

    void ReplaceOne(T document);

    Task ReplaceOneAsync(T document);

    void DeleteOne(Expression<Func<T, bool>> filterExpression);

    Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

    void DeleteById(string id);

    Task DeleteByIdAsync(string id);

    void DeleteMany(Expression<Func<T, bool>> filterExpression);

    Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
}
