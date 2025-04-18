using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetUserCartAsync(string userId);
        Task AddToCartAsync(CartItem item);
        Task RemoveFromCartAsync(string id);
        Task<CartItem> GetByIdAsync(string id);
    }
}
