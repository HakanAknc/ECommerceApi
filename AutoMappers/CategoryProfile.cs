using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;

namespace ECommerceApi.AutoMappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
