using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;

        public CategoryRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Category>(settings.Value.CategoriesCollection);
        }

        public async Task<List<Category>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Category> GetByIdAsync(string id) =>
            await _collection.Find(c =>  c.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category category) =>
            await _collection.InsertOneAsync(category);

        public async Task UpdateAsync(string id, Category category) =>
            await _collection.ReplaceOneAsync(c =>  c.Id == id, category);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(c => c.Id == id);
    }
}
