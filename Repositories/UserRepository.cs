using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<User>(settings.Value.UsersCollection);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }
    }
}
