using ECommerceApi.DTOs;

namespace ECommerceApi.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(string id);
        Task CreateAsync(CategoryDto dto);
        Task UpdateAsync(string id, CategoryDto dto);
        Task DeleteAsync(string id);
    }
}
