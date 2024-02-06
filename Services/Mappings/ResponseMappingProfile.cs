using AutoMapper;
using api_scango.Domain.Entities;
using api_scango.Domain.Dtos;



namespace api_scango.Services.Mappings;

public class ReponseMappingProfile : Profile
{
    public ReponseMappingProfile() 
    { 
        CreateMap<Cliente, ClienteDto>()
        .ForMember( dest => dest.NumeroTelefonico, opt => opt.MapFrom(src => src.NumeroTelefono))
        .ForMember( dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
        .ForMember( dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
        .ForMember( dest => dest.Correo, opt => opt.MapFrom(src => src.Correo));
        // .ForMember( dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));



        // CreateMap<Producto, ProductoDto>()
        // .ForMember( dest => dest.Codigodebarras, opt => opt.MapFrom(src => src.Codigodebarras))
        // .ForMember( dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
        // .ForMember( dest => dest.Precio, opt => opt.MapFrom(src => src.Precio));
        // // .ForMember( dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));
        // // .ForMember( dest => dest.Imagen, opt => opt.MapFrom(src => src.Imagen));

        //  CreateMap<ProductoEnCarrito, ProductoEnCarritoDto>()
        //         // .ForMember(dest => dest.IdCarrito, opt => opt.MapFrom(src => src.IdCarrito))
        //         .ForMember(dest => dest.Codigodebarras, opt => opt.MapFrom(src => src.Codigodebarras))
        //         .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
        //         .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
        //          .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.ProductoNombre ?? "no hay nombre xd"));


         CreateMap<Establecimiento, EstablecimientoDTO>()
         .ForMember(dest => dest.idSuper, opt => opt.MapFrom(src => src.IdEstablecimiento))

         .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
         .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.Imagen))
         .ForMember(dest => dest.IdInventar, opt => opt.MapFrom(src => src.IdInventario))
         .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
         .ForMember(dest => dest.Longitud, opt => opt.MapFrom(src => src.Longitud))
         .ForMember(dest => dest.Latitud, opt => opt.MapFrom(src => src.Longitud));

            CreateMap<Administrador, Administrador>()
         .ForMember(dest => dest.IdAdministrador, opt => opt.MapFrom(src => src.IdAdministrador))

         .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
         .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo));
        //  .ForMember(dest => dest.IdInventar, opt => opt.MapFrom(src => src.IdInventario))
        //  .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))





    }

}