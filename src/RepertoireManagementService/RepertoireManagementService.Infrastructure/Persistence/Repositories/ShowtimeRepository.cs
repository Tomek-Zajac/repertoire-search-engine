using Domain.Entities;
using MongoDB.Driver;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;

namespace RepertoireManagementService.Infrastructure.Persistence.Repositories;

public class ShowtimeRepository : IRepository<ShowtimeEntity>
{
    private readonly IMongoCollection<ShowtimeEntity> _collection;

    public ShowtimeRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase("repertoireSearchEngineDB");
        _collection = database.GetCollection<ShowtimeEntity>("showtime");
    }

    public async Task<IEnumerable<ShowtimeEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _collection.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);

    public async Task<ShowtimeEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _collection.Find(c => c.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<ShowtimeEntity> AddAsync(ShowtimeEntity entity, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<bool> UpdateAsync(ShowtimeEntity entity, CancellationToken cancellationToken = default)
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