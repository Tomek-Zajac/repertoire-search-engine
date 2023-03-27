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

    public async Task<IEnumerable<CinemaEntity>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<CinemaEntity> GetByIdAsync(string id)
    {
        return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(CinemaEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(CinemaEntity entity)
    {
        await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);
    }

    public async Task DeleteAsync(CinemaEntity entity)
    {
        await _collection.DeleteOneAsync(c => c.Id == entity.Id);
    }
}