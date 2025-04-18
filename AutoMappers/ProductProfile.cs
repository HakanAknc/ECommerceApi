using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;

namespace ECommerceApi.AutoMappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
