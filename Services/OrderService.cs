using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<Order>> GetByUserAsync(string userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task CreateAsync(OrderDto dto)
        {
            var total = dto.Items.Sum(i => i.Quantity * 100); // ürün fiyatları henüz alınmadı, örnek için 100₺ varsaydık

            var order = new Order
            {
                UserId = dto.UserId,
                Items = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList(),
                TotalPrice = total
            };

            await _repo.CreateAsync(order);
        }
    }
}
