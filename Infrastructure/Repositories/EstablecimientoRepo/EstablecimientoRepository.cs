

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


}