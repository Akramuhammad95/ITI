using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CachedRepository<T> : IBaseRepository<T> where T : class
{
    private readonly IBaseRepository<T> _repository;
    private readonly ICacheService _cache;

    public CachedRepository(IBaseRepository<T> repository, ICacheService cache)
    {
        _repository = repository;
        _cache = cache;
    }

    private string GetKey(string suffix) =>
        $"{typeof(T).Name}:{suffix}";

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var key = GetKey("All");

        var cached = await _cache.GetAsync<IEnumerable<T>>(key);

        if (cached != null)
            return cached;

        var data = await _repository.GetAllAsync();

        await _cache.SetAsync(key, data, TimeSpan.FromMinutes(10));

        return data;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var key = GetKey($"Id:{id}");

        var cached = await _cache.GetAsync<T>(key);

        if (cached != null)
            return cached;

        var entity = await _repository.GetAsync(id);

        if (entity != null)
            await _cache.SetAsync(key, entity, TimeSpan.FromMinutes(10));

        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        var result = await _repository.AddAsync(entity);

        await InvalidateCache();

        return result;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var result = await _repository.UpdateAsync(entity);

        await InvalidateCache();

        return result;
    }

    public async Task<T> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);

        await InvalidateCache();

        return result;
    }

    private async Task InvalidateCache()
    {
        await _cache.RemoveAsync(GetKey("All"));
    }
}
