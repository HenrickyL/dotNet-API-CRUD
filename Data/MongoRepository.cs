using MongoDB.Driver;

namespace StudentApi.Data;

public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly IMongoCollection<TEntity> _collection;

    public MongoRepository(MongoDbContext context)
    {
        string collectionName = typeof(TEntity).Name + 's';
        _collection = context.GetDatabase().GetCollection<TEntity>(collectionName);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _collection.Find(Builders<TEntity>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _collection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id));
    }
}