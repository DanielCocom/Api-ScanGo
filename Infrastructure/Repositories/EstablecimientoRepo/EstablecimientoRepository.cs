

using api_scango.Domain.Dtos;
using api_scango.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api_scango.Infrastructure.Data.Repositories;


public class EstablecimientoRepository
{

    private readonly ScanGoDbContext _dbContext;
    public EstablecimientoRepository(ScanGoDbContext scanGoDbContext)
    {
        _dbContext = scanGoDbContext;
    }
    public async Task<IEnumerable<Establecimiento>> GetAll()
    {
        var establecimiento = await _dbContext.Establecimiento.ToListAsync();
        return establecimiento;
    }
    public async Task<Establecimiento> GetById(int id)
    {
        var establecimiento = await _dbContext.Establecimiento.FirstOrDefaultAsync(establecimeinto => establecimeinto.IdEstablecimiento == id);

        return establecimiento ?? new Establecimiento();
    }
    public async Task Add(Establecimiento establecimiento)
    {
        await _dbContext.AddAsync(establecimiento);
        await _dbContext.SaveChangesAsync();

        var newInventario = new Inventario();
        _dbContext.Add(newInventario);
        await _dbContext.SaveChangesAsync();

        establecimiento.IdInventario = newInventario.IdInventario;

        await _dbContext.SaveChangesAsync();
    } 


    public async Task Update(Establecimiento establecimiento)
    {
        var establecimeinto = await _dbContext.Establecimiento.FirstOrDefaultAsync(x => x.IdEstablecimiento == establecimiento.IdEstablecimiento);
        if (establecimeinto != null)
        {
            _dbContext.Entry(establecimeinto).CurrentValues.SetValues(establecimiento);
        }
    }
    public async Task Delete(int id)
    {
        var esta = await _dbContext.Establecimiento.FirstOrDefaultAsync(x => x.IdEstablecimiento == id);
        if (esta != null)
        {
            _dbContext.Establecimiento.Remove(esta);
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task<List<InventarioDTO>> GetInventario(int IdEstablecimiento)
    {
        // buscas primero el establecimiento y despues el inventario, para obtener los productos
        var establecimeinto = await _dbContext.Establecimiento
        .Include(inventario => inventario.IdInventarioNavigation)
         .FirstOrDefaultAsync(establecimeinto => establecimeinto.IdEstablecimiento == IdEstablecimiento);


        var inventario = await _dbContext.Inventario
        .Include(c => c.ProductoInventario)
        .FirstOrDefaultAsync(inventario => inventario.IdInventario == establecimeinto.IdInventario);

        var productosEnInventario = await _dbContext.ProductoInventario
        .Where(pi => pi.IdInventario == inventario.IdInventario)
        .Select(pi => new InventarioDTO
        {
            // Aquí mapea los campos que deseas incluir en tu DTO
            IdProducto = pi.IdProducto,
            NombreProducto = pi.IdProductoNavigation.Nombre, // Ejemplo de cómo acceder al nombre del producto
            Cantidad = pi.Cantidad,
            Imagen = pi.IdProductoNavigation.Imagen,
            Precio = pi.IdProductoNavigation.Precio
        })
        .ToListAsync();

        return productosEnInventario;

    }
  public async Task<List<Producto>> SearchProduct(string valueToSearch)
{
    IQueryable<Producto> query = _dbContext.Producto;

    if (!string.IsNullOrEmpty(valueToSearch))
    {
        query = query.Where(p => p.IdProducto.Contains(valueToSearch) || p.Nombre.Contains(valueToSearch));
    }

    return await query.ToListAsync();
}

    
   



}