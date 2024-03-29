﻿using Domain.Interfaces;

namespace Persistence.Repository.Repositories.Interface;

public interface IRepository<T> where T : IEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}