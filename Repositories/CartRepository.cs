using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IMongoCollection<CartItem> _collection;

        public CartRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<CartItem>(settings.Value.CartItemsCollection);
        }

        public async Task<List<CartItem>> GetUserCartAsync(string userId)
        {
            return await _collection.Find(c => c.UserId == userId).ToListAsync();
        }

        public async Task AddToCartAsync(CartItem item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task RemoveFromCartAsync(string id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<CartItem> GetByIdAsync(string id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
