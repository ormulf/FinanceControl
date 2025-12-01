using FinanceControl.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceControl.Infrastructure.Mongo.Repositories
{
    public abstract class MongoRepositoryBase<T> : IRepositoryBase<T>
    {
        protected readonly IMongoCollection<T> _collection;
        public MongoRepositoryBase(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public virtual async Task AddAsync(T entity) => await _collection.InsertOneAsync(entity);
        public virtual async Task DeleteAsync(int id) => await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T?> GetByIdAsync(int id);
        public virtual async Task UpdateAsync(T entity, int id) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
    }
}
