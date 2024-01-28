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
        .ForMember( dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
        .ForMember( dest => dest.Correo, opt => opt.MapFrom(src => src.Correo));
        // .ForMember( dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));



        CreateMap<Producto, ProductoDto>()
        .ForMember( dest => dest.Codigodebarras, opt => opt.MapFrom(src => src.Codigodebarras))
        .ForMember( dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
        .ForMember( dest => dest.Precio, opt => opt.MapFrom(src => src.Precio));
        // .ForMember( dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));
        // .ForMember( dest => dest.Imagen, opt => opt.MapFrom(src => src.Imagen));

         CreateMap<ProductoEnCarrito, ProductoEnCarritoDto>()
                // .ForMember(dest => dest.IdCarrito, opt => opt.MapFrom(src => src.IdCarrito))
                .ForMember(dest => dest.Codigodebarras, opt => opt.MapFrom(src => src.Codigodebarras))
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                 .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.ProductoNombre ?? "no hay nombre xd"));


         CreateMap<Establecimiento, EstablecimientoDTO>()
         .ForMember(dest => dest.idSuper, opt => opt.MapFrom(src => src.IdEstablecimiento))

         .ForMember(dest => dest.NombreEstablecimiento, opt => opt.MapFrom(src => src.NombreEstablecimiento))
         .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
         .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
         .ForMember(dest => dest.NombreBaseDatos, opt => opt.MapFrom(src => src.NombreBaseDatos))
         .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));







    }

}