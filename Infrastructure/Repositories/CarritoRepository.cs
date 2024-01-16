using System.Threading.Tasks;
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using api_scango.Domain.Dtos;

namespace api_scango.Infrastructure.Data.Repositories;

public class CarritoRepository
{
    private readonly ScanGoDb _context;
    private readonly ClienteRepository _clienteRepository;
    private readonly ProductoRepository _productoRepository;
    private readonly IMapper _mapper;

    public CarritoRepository(ScanGoDb scanGoDb, ClienteRepository clienteRepository, ProductoRepository productoRepository, IMapper mapper)
    {
        this._productoRepository = productoRepository;
        this._clienteRepository = clienteRepository;
        this._context = scanGoDb;
        this._mapper = mapper;
    }
    public async Task AddProducto(string numerodetelefono, string codigodebarras, int cantidad)
    {
        var cliente = await _clienteRepository.GetById(numerodetelefono);
        var producto = await _productoRepository.GetById(codigodebarras);

        // FIXME: agregar por si no existe el producto
        if (producto == null)
        {
            throw new Exception("No Se encontro el producto");
        }

        var carrito = cliente.IdCarritoNavigation;

        // Verificar si el producto ya está en el carrito
        var productoEnCarrito = carrito!.ProductoEnCarrito
            .FirstOrDefault(p => p.Codigodebarras == codigodebarras);

        if (productoEnCarrito != null)
        {
            productoEnCarrito.Cantidad += cantidad;
            productoEnCarrito.Total += producto.Precio * cantidad;
        }
        else
        {
            carrito!.ProductoEnCarrito.Add(new ProductoEnCarrito
            {
                // es importante asignar los valores cuando se instancia el objeto
                Codigodebarras = producto.Codigodebarras,
                 ProductoNombre = producto.Nombre,
                Cantidad = cantidad,
                Total = producto.Precio
            });
        }

        await _context.SaveChangesAsync();

    }



    public async Task<List<ProductoEnCarritoDto>> GetProductos(string numerodetelefono)
    {
        var cliente = await _context.Cliente
    .Include(c => c.IdCarritoNavigation)
    .ThenInclude(c => c!.ProductoEnCarrito)
    .ThenInclude(pc => pc.CodigodebarrasNavigation) // Asegúrate de incluir la entidad de Producto
    .FirstOrDefaultAsync(c => c.Numerodetelefono == numerodetelefono);

        var productosEnCarrito = cliente!.IdCarritoNavigation!.ProductoEnCarrito.ToList();

        var productosEnCarritoDto = _mapper.Map<List<ProductoEnCarritoDto>>(productosEnCarrito);

        return productosEnCarritoDto;

    }
}






