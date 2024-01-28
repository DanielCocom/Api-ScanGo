using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using api_scango.Domain.Dtos;

namespace api_scango.Infrastructure.Data.Repositories;

public class CompraRepository{
    private readonly ScanGoDb _context;
    private readonly CarritoRepository _carritoRepository;
    private readonly ClienteRepository _clienteRepository;


    public CompraRepository(ScanGoDb scanGoDb, CarritoRepository carritoRepository, ClienteRepository clienteRepository){
        _context = scanGoDb;
        _carritoRepository = carritoRepository;
        _clienteRepository = clienteRepository; 

    
    }
    public async Task VaciarCarrito(string numerodetelefono){

        // FIXME: NO se guardan los productos en mi tabla de detalle compra
        Carrito? carrito = null;
        var cliente = await _clienteRepository.GetById(numerodetelefono);
        if(cliente == null){
            throw new Exception("No existe el cliente");

        }

         carrito = cliente.IdCarritoNavigation;

        if(carrito!.ProductoEnCarrito.Count == 0){
            throw new Exception("No se puede realizar la compra el Carrito esta vacio");
        }


        
        if(carrito!.ProductoEnCarrito.Any())
        {
            var nuevaCompra = new Compra{
                Numerodetelefono =numerodetelefono,
                FechaDeCompra = DateTime.Now,
                Subtotal = carrito.ProductoEnCarrito.Sum(p => p.Total) 

            };
            
            _context.Add(nuevaCompra);

            // Agregar los productos a la compra
            foreach(var productoEnCarrito in carrito.ProductoEnCarrito)
            {
                var detalle = new DetalleCompra{
                    Codigodebarras = productoEnCarrito.Codigodebarras,
                    ProductoNombre = productoEnCarrito.ProductoNombre,
                    Cantidad = productoEnCarrito.Cantidad,
                    Total = productoEnCarrito.Total
                };
            }

        }
        carrito.ProductoEnCarrito.Clear();
        await _context.SaveChangesAsync();
        // if(carrito != null){
        //     _context.Carrito.Remove(carrito);
        // }
    
    }

}