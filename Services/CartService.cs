using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;
    private readonly IMapper _mapper;

    public CartService(ICartRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<CartItem>> GetMyCartAsync(string userId)
    {
        return await _repo.GetUserCartAsync(userId);
    }

    public async Task AddAsync(string userId, CartItemDto dto)
    {
        var item = new CartItem
        {
            UserId = userId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity
        };

        await _repo.AddToCartAsync(item);
    }

    public async Task RemoveAsync(string cartItemId)
    {
        await _repo.RemoveFromCartAsync(cartItemId);
    }
}
}
