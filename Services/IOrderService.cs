using ECommerceApi.DTOs;
using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetByUserAsync(string userId);
        Task CreateAsync(OrderDto dto);
    }
}
