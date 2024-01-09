using api_scango.Infrastructure.Data.Repositories;
using api_scango.Domain.Entities;

namespace api_scango.Services.Fetures.producto;

public class ProductoService
{
    private readonly ProductoRepository _productoRository;
    public ProductoService(ProductoRepository productoRepository)
    {
        this._productoRository = productoRepository;


    }
    public async Task<IEnumerable<Producto>> GetAllProductos()
    {
        return await _productoRository.GetAll();
    }
    public async Task<Producto> GetById(string id)
    {
        return await _productoRository.GetById(id);
    }
    public async Task Add(Producto producto)
    {
        await _productoRository.Add(producto);
    }
}