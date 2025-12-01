using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using MongoDB.Driver;

namespace FinanceControl.Infrastructure.Mongo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;
        public CategoryRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<Category>("Categories");
        }

        public async Task AddAsync(Category entity) => await _collection.InsertOneAsync(entity);

        public async Task DeleteAsync(int id) =>
            await _collection.DeleteOneAsync(c => c.Id == id);

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Category?> GetByIdAsync(int id) =>
            await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Category entity) =>
            await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);

        public async Task UpdateAsync(Category entity, int id)=>
            await UpdateAsync(entity);

    }
}

