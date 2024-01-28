using AutoMapper;
using api_scango.Domain.Dtos;
using api_scango.Domain.Entities;

namespace api_scango.Services.Mappings;

public class RequestMappingProfile : Profile
{
    public RequestMappingProfile(){
        CreateMap<ClienteCreateDTO, Cliente>();
        CreateMap<ProductoCreateDto, Producto>();
         CreateMap<ProductoEnCarrito, ProductoEnCarritoDto>().ReverseMap();
         CreateMap<EstablecimientoDTO, Establecimiento>();
         CreateMap<ClienteLoginDTO, Cliente>();


    }
    
}