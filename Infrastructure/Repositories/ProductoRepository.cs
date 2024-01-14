using System.Text.Json;
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace api_scango.Infrastructure.Data.Repositories;

public class ProductoRepository
{
    private readonly ScanGoDb _context;
    public ProductoRepository(ScanGoDb context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Producto>> GetAll(){
        var productos = await _context.Producto.ToListAsync();
        return productos;
    }
    public async Task<Producto> GetById(string id){
        var producto = await _context.Producto.FirstOrDefaultAsync(producto => producto.Codigodebarras == id);
        return producto ?? new Producto();
    }
      
    // update  por si lo necesito
    public async Task Delete(string id){
        var producto = await _context.Producto.FirstOrDefaultAsync(producto => producto.Codigodebarras == id);
        if(producto != null){
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            //hay que hacer esto
        }
    }
}