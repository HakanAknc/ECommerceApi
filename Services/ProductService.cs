using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(string id)
        {
            var product = await _repo.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task CreateAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repo.CreateAsync(product);
        }

        public async Task UpdateAsync(string id, ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = id;
            await _repo.UpdateAsync(id, product);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
