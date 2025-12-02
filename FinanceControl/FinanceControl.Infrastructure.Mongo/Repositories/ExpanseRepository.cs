using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using MongoDB.Driver;

namespace FinanceControl.Infrastructure.Mongo.Repositories
{
    public class ExpanseRepository : IExpanseRepository
    {
        private readonly IMongoCollection<Expanse> _collection;
        public ExpanseRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<Expanse>("Expanses");
        }

        public async Task AddAsync(Expanse entity) => await _collection.InsertOneAsync(entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(e => e.Id == id);

        public async Task<IEnumerable<Expanse>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Expanse?> GetByIdAsync(string id) =>
            await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Expanse entity) =>
            await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);      

        public async Task<IEnumerable<Expanse>> GetByCategoryIdAsync(string categoryId) =>
            await _collection.Find(e => e.CategoryId == categoryId).ToListAsync();
    }
}
