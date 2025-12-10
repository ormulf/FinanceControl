using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceControl.Domain.Entities
{
    public class Expanse
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CategoryId { get; set; }
        public Category ?ExpanseCategory { get; set; } = new Category();
        public decimal Value { get; set; }
        public string ?Description { get; set; }
        public DateOnly When { get; set; }
        public bool IsCreditCard { get; set; }

    }

}
