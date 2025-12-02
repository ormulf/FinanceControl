using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceControl.Domain.Entities
{
    public class Expanse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public Category ?ExpanseCategory { get; set; } = new Category();
        public float Value { get; set; }
        public string ?Description { get; set; }
        public DateOnly When { get; set; }
    }

}
