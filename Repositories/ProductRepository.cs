using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Product>(settings.Value.ProductsCollection);
        }

        public async Task<List<Product>> GetAllAsync() => 
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Product> GetByIdAsync(string id) =>
            await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product product) => 
            await _collection.InsertOneAsync(product);

        public async Task UpdateAsync(string id, Product product) =>
            await _collection.ReplaceOneAsync(p => p.Id == id, product);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(p => p.Id == id);
    }
}
