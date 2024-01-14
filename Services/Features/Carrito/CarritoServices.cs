using api_scango.Infrastructure.Data.Repositories;
using api_scango.Domain.Dtos;
using AutoMapper;

public class CarritoService
{
    private readonly CarritoRepository _carritoRepository;

    public CarritoService(CarritoRepository carritoRepository)
    {
        _carritoRepository = carritoRepository;
    }

    public async Task AgregarProductoAlCarrito(string numerodetelefono, string codigodebarras, int cantidad)
    {
        await _carritoRepository.AddProducto(numerodetelefono, codigodebarras, cantidad);
    }
    public async Task<List<ProductoEnCarritoDto>> GetProductos(string numerodetelefono)
{
    return await _carritoRepository.GetProductos(numerodetelefono);
}


}
