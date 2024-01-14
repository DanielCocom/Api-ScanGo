using System.Threading.Tasks;
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_scango.Infrastructure.Data.Repositories
{
    // public interface IClienteRepository
    // {
    //     Task<Cliente> GetById(int numerodetelefono);

    //     Task AgregarClienteAsync(Cliente cliente);

    //     // Otros métodos relacionados con la entidad Cliente si es necesario
    // }

    public class ClienteRepository
    {
        private readonly ScanGoDb _context;

        public ClienteRepository(ScanGoDb dbContext)
        {
            _context = dbContext;
        }

        public async Task<Cliente> GetById(string numerodetelefono)
        {
            var cliente = await _context.Cliente
                .Include(c => c.IdCarritoNavigation.ProductoEnCarrito) // Incluir carga ansiosa del carrito
                .FirstOrDefaultAsync(cliente => cliente.Numerodetelefono == numerodetelefono);

            return cliente ?? new Cliente();
        }


        public async Task AgregarClienteAsync(Cliente cliente)
        {
            var newCarrito = new Carrito();
            _context.Add(newCarrito);
            await _context.SaveChangesAsync();

            cliente.IdCarrito = newCarrito.IdCarrito;

            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();

        }
        // actualizarCliente


        // Implementa otros métodos según sea necesario
    }
}
