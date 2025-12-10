using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using FinanceControl.Domain.ReadModel;
using FinanceControl.Infrastructure.Mongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinanceControl.Infrastructure.Mongo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;
        private readonly IMongoCollection<Expanse> _collectionExpanse;
        public CategoryRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<Category>("Categories");
            _collectionExpanse = db.GetCollection<Expanse>("Expanses");
        }

        public async Task AddAsync(Category entity) => await _collection.InsertOneAsync(entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(c => c.Id == ObjectId.Parse(id));

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<IEnumerable<CategoryMonthlySummaryReadModel>> GetCategorySummaryAsync(DateTime monthToReport)
        {
            var nextMonth = monthToReport.AddMonths(1);

            var result = await _collection.Aggregate()
                .Lookup<Category, Expanse, CategoryJoined>(
                    _collectionExpanse,
                    c => c.Id,
                    e => e.CategoryId,
                    j => j.Expanses)
                .AppendStage<CategoryJoined>(new BsonDocument {
            { "$addFields",
                new BsonDocument("FilteredExpanses",
                    new BsonDocument("$filter",
                        new BsonDocument {
                            { "input", "$Expanses" },
                            { "as", "e" },
                            { "cond",
                                new BsonDocument("$and", new BsonArray {
                                    new BsonDocument("$gte",
                                        new BsonArray { "$$e.When", monthToReport.AddDays(-1) }),
                                    new BsonDocument("$lt",
                                        new BsonArray { "$$e.When", nextMonth })
                                })
                            }
                        }
                    )
                )
            }
                })
                .Project<CategoryMonthlySummaryReadModel>(Builders<CategoryJoined>.Projection
                    .Expression(c => new CategoryMonthlySummaryReadModel
                    {
                        Id = c.Id.ToString(),
                        Name = c.Name,
                        Limit = c.Limit,
                        Type = c.Type,
                        TotalExpanses = c.FilteredExpanses != null ? c.FilteredExpanses.Sum(e => e.Value) : 0
                    }))
                .ToListAsync();

            return result;
        }


        public async Task<Category?> GetByIdAsync(string id) =>
            await _collection.Find(c => c.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();

        public async Task UpdateAsync(Category entity) =>
            await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);

        public async Task UpdateAsync(Category entity, int id)=>
            await UpdateAsync(entity);

    }
    
}

