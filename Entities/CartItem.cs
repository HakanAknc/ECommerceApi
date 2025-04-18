using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceApi.Entities
{
    public class CartItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("userId")]
        public string UserId { get; set; }


        [BsonElement("ProductId")]
        public string ProductId { get; set; }


        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }
}
