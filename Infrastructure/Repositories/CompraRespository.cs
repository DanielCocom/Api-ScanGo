using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using api_scango.Domain.Dtos;

namespace api_scango.Infrastructure.Data.Repositories;

public class CompraRepository
{
    private readonly ScanGoDbContext _context;
    private readonly VentaRepository _repsoitory;
    public CompraRepository(ScanGoDbContext scanGoDbContext, VentaRepository ventaRepository)
    {
        _context = scanGoDbContext;
        _repsoitory = ventaRepository;

    }
    public async Task <Venta> RealizarCompra(int idEstablecimiento, string numerodetelefono)
    {
        var cliente = await _context.Cliente
         .Include(c => c.IdCarritoNavigation)
         .ThenInclude(carrito => carrito!.ProductosEnCarrito)
             .ThenInclude(producto => producto.IdProductoNavigation)
                .FirstOrDefaultAsync(c => c.NumeroTelefono == numerodetelefono);

        if (cliente == null || cliente.IdCarritoNavigation == null)
        {
            throw new Exception("Cliente no encontrado o carrito vacío");
        }

        // Calcular el total pagado sumando los totales de los productos en el carrito
        decimal totalPagado = (decimal)cliente.IdCarritoNavigation.ProductosEnCarrito.Sum(pc => pc.Total)!;

        // Crear la nueva venta
        var nuevaVenta = new Venta
        {
            FechaVenta = DateTime.Now,
            TotalPagado = totalPagado,
            IdEstablecimiento = idEstablecimiento,
            IdTransaccion ="no hay"
            // IdTransaccion = Idtransaccion
            
            // campo id de la transaccion
        };

        // Agregar la nueva venta al contexto
        _context.Venta.Add(nuevaVenta);
        await _context.SaveChangesAsync();

        // Registrar el detalle de la venta
        foreach (var productoEnCarrito in cliente.IdCarritoNavigation.ProductosEnCarrito)
        {
            var nuevoDetalleVenta = new DetalleVenta
            {
                IdVenta = nuevaVenta.IdVenta,
                IdProducto = productoEnCarrito.IdProducto,
                Cantidad = productoEnCarrito.Cantidad,
                PrecioUnitario = productoEnCarrito.IdProductoNavigation!.Precio, // Obtener el precio del producto
                Total = productoEnCarrito.Total
            };
            _context.DetalleVenta.Add(nuevoDetalleVenta);
        }

        // Limpiar el carrito del cliente
        // cliente.IdCarritoNavigation.ProductosEnCarrito.Clear();
        await _context.SaveChangesAsync();

        return nuevaVenta;
    }

   



}
