using AutoMapper;
using FinanceControl.Application.DTOs;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Enums;

namespace FinanceControl.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Domain → DTO
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type));

            // DTO → Domain
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (CategoryType)src.Type))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (CategoryType)src.Type));
        }
    }
}
