using ECommerceApi.DTOs;
using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public class ICartService
    {
        Task<List<CartItem>> GetMyCartAsync(string userId);
        Task AddAsync(string userId, CartItemDto dto);
        Task RemoveAsync(string cartItemId);
    }
}
