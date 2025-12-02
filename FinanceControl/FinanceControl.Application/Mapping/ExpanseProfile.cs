using AutoMapper;
using FinanceControl.Application.DTOs;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Mapping
{
    public class ExpanseProfile : Profile
    {
        public ExpanseProfile()
        {
            // Domain -> DTO
            CreateMap<Expanse, ExpanseDto>()
                .ForMember(dest => dest.When, opt => opt.MapFrom(src => src.When.ToDateTime(TimeOnly.MinValue)));

            // Create DTO -> Domain
            CreateMap<CreateExpanseDto, Expanse>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.When, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.When)));
        }
    }
}
