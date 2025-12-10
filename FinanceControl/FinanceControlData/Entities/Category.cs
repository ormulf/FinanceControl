using FinanceControl.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceControl.Domain.Entities
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Limit { get; set; } = 0;
        public CategoryType Type { get; set; }
    }

}
