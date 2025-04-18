using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceApi.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
