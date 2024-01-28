using api_scango.Infrastructure.Data.Repositories;
using api_scango.Domain.Entities;


namespace api_scango.Services.Fetures.compra;


public class CompraServices{
    private readonly CompraRepository _repository;

    public CompraServices(CompraRepository compraRepository){
        this._repository = compraRepository;
    }
    // public async Task<IEnumerable<Compra>> GetCompras(){
// 
        // return await _repository
    // }


    public async Task RealizarCompra(string numerodetelefono){

        await _repository.VaciarCarrito(numerodetelefono);

    }
}