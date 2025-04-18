using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
