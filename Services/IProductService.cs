using ECommerceApi.DTOs;

namespace ECommerceApi.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(string id);
        Task CreateAsync(ProductDto dto);
        Task UpdateAsync(string id, ProductDto dto);
        Task DeleteAsync(string id);
    }
}
