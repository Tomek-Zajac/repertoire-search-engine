using Domain.Entities;
using MongoDB.Driver;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;

namespace RepertoireManagementService.Infrastructure.Persistence.Repositories;

public class CinemaRepository : IRepository<CinemaEntity>
{
    private readonly IMongoCollection<CinemaEntity> _collection;

    public CinemaRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase("repertoireSearchEngineDB");
        _collection = database.GetCollection<CinemaEntity>("cinemas");
    }

    public async Task<IEnumerable<CinemaEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _collection.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);

    public async Task<CinemaEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _collection.Find(c => c.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<CinemaEntity> AddAsync(CinemaEntity entity, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<bool> UpdateAsync(CinemaEntity entity, CancellationToken cancellationToken = default)
    {
        var updateResult = await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);
        return updateResult.IsAcknowledged;
    }

    public async Task<bool> DeleteAsync(string entity, CancellationToken cancellationToken = default)
    {
        var deleteResult = await _collection.DeleteOneAsync(c => c.Id == entity, cancellationToken: cancellationToken);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}