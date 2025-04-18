using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Order>(settings.Value.OrdersCollection);
        }

        public async Task<List<Order>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<List<Order>> GetByUserIdAsync(string userId) =>
            await _collection.Find(o => o.UserId == userId).ToListAsync();

        public async Task CreateAsync(Order order) =>
            await _collection.InsertOneAsync(order);
    }
}
