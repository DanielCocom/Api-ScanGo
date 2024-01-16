
using api_scango.Domain.Entities;
using api_scango.Infrastructure.Data.Repositories;

namespace api_scango.Services.Fetures.establecimiento;

public class EstablecimientoService
{
    private readonly EstablecimientoRepository _repository;

    public EstablecimientoService(EstablecimientoRepository establecimientoRepository)
    {
        this._repository = establecimientoRepository;
    }
    public async Task<IEnumerable<Establecimiento>> getAll()
    {
        return await _repository.GetAll();
    }
    public async Task<Establecimiento> GetById(int id)
    {
        return await _repository.GetById(id);
    }
    public async Task Add(Establecimiento establecimiento)
    {
        await _repository.Add(establecimiento);
    }
    public async Task Update(Establecimiento estaUpdate)
    {
        var establecimeinto = GetById(estaUpdate.IdEstablecimiento);
        if (establecimeinto.Id > 0)
        {
            await _repository.Update(estaUpdate);
        }
    }
    public async Task Delete(int id)
    {
        var esta = GetById(id);
        if(esta.Id > 0){
            await _repository.Delete(id);
        }
    }
}