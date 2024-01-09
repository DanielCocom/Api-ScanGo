using AutoMapper;
using api_scango.Domain.Dtos;
using api_scango.Domain.Entities;

namespace api_scango.Services.Mappings;

public class RequestMappingProfile : Profile
{
    public RequestMappingProfile(){
        CreateMap<ClienteCreateDTO, Cliente>();
    }
    
}