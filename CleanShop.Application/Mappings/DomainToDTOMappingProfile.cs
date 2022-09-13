using AutoMapper;

using CleanShop.Application.DTO;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Mappings;
public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}