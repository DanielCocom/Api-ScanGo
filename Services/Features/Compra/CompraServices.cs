using api_scango.Infrastructure.Data.Repositories;
using api_scango.Domain.Entities;


namespace api_scango.Services.Fetures.compra;


public class CompraService
{

    private readonly CompraRepository _repositpory;

    public CompraService(CompraRepository compraRepository)
    {
        _repositpory = compraRepository;
    }

    public async Task<Venta> RealizarCompra(int idEstablecimiento, string numerodetelefono)
    {
        return await _repositpory.RealizarCompra(idEstablecimiento, numerodetelefono);
    }

}