using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceControl.Domain.Entities
{
    public class Expanse
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category ?ExpanseCategory { get; set; } = new Category();
        public float Value { get; set; }
        public DateOnly When { get; set; }
    }

}
