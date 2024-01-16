

using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_scango.Infrastructure.Data.Repositories;


public class EstablecimientoRepository
{

    private readonly ScanGoDb _context;

    public EstablecimientoRepository(ScanGoDb context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Establecimiento>> GetAll()
    {
        var establecimiento = await _context.Establecimiento.ToListAsync();
        return establecimiento;
    }


    public async Task<Establecimiento> GetById(int id){
        var establecimiento = await _context.Establecimiento.FirstOrDefaultAsync(establecimeinto => establecimeinto.IdEstablecimiento == id);

        return establecimiento ?? new Establecimiento();
    }
    public async Task Add(Establecimiento establecimiento){
        await _context.AddAsync(establecimiento);
        await _context.SaveChangesAsync();

    
    }

    public async Task Update(Establecimiento establecimiento){
        var establecimeinto = await _context.Establecimiento.FirstOrDefaultAsync(x => x.IdEstablecimiento == establecimiento.IdEstablecimiento);
        if(establecimeinto != null){
            _context.Entry(establecimeinto).CurrentValues.SetValues(establecimiento);
        }
    }
    public async Task Delete(int id){
        var esta = await _context.Establecimiento.FirstOrDefaultAsync(x => x.IdEstablecimiento == id);
        if(esta != null){
            _context.Establecimiento.Remove(esta);
            await _context.SaveChangesAsync();
        }
    }


}