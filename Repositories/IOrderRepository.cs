using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetByUserIdAsync(string userId);
        Task CreateAsync(Order order);
    }
}
