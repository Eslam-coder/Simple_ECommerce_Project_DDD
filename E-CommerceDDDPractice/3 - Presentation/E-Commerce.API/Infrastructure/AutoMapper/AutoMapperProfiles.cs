using _1___Domain.Categories.Entities;
using _1___Domain.Orders.Entities;
using _1___Domain.Products.Entities;
using AutoMapper;
using E_Commerce.API.Categories.Dtos;
using E_Commerce.API.Orders.Dtos;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Infrastructure.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
