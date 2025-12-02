using FinanceControl.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceControl.Domain.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Limit { get; set; } = 0f;
        public CategoryType Type { get; set; }
    }

}
