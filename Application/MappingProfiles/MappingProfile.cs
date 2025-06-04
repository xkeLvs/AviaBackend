using AutoMapper;
using AviaBackend.Application.DTOs.Category;
using AviaBackend.Application.DTOs.Product;
using AviaBackend.Domain.Entities;

namespace AviaBackend.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap()
             .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
