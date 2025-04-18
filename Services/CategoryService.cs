using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(string id)
        {
            var category = await _repo.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task CreateAsync(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _repo.CreateAsync(category);
        }

        public async Task UpdateAsync(string id, CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            category.Id = id;
            await _repo.UpdateAsync(id, category);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
