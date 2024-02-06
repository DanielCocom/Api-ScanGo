using System.Text.Json;
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace api_scango.Infrastructure.Data.Repositories;

public class ProductoRepository
{
    private readonly ScanGoDbContext _context;
    private readonly EstablecimientoRepository _establecimientoRepo;

    public ProductoRepository(ScanGoDbContext scanGoDbContext, EstablecimientoRepository establecimientoRepository)
    {
        _context = scanGoDbContext;
        _establecimientoRepo = establecimientoRepository;
    }
    public async Task<Producto> GetPRoductsStock(string idProducto, int idEstablecimiento)
    {
        return new Producto();
    }
    public async Task AddProducto(int idEstablecimiento, Producto producto)
    {
        
    }
    // public async Task




}