using AutoMapper;
using api_scango.Domain.Entities;
using api_scango.Domain.Dtos;



namespace api_scango.Services.Mappings;

public class ReponseMappingProfile : Profile
{
    public ReponseMappingProfile() 
    { 
        CreateMap<Cliente, ClienteDto>()
        .ForMember( dest => dest.NumeroTelefonico, opt => opt.MapFrom(src => src.Numerodetelefono))
        .ForMember( dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
        .ForMember( dest => dest.Correo, opt => opt.MapFrom(src => src.Correo));

    }

}