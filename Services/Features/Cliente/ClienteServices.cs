using System.Threading.Tasks;
using api_scango.Domain.Entities;
using api_scango.Infrastructure.Data.Repositories;

namespace api_scango.Domain.Services
{
    // public interface IClienteService
    // {
    //     Task<Cliente> ObtenerClientePorTelefonoAsync(int numerodetelefono);

    //     Task RegistrarNuevoClienteAsync(Cliente nuevoCliente);
    // }

    public class ClienteService 
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> ObtenerClientePorTelefonoAsync(int numerodetelefono)
        {
            return await _clienteRepository.GetById(numerodetelefono);
        }

        public async Task RegistrarNuevoClienteAsync(Cliente nuevoCliente)
        {
            await _clienteRepository.AgregarClienteAsync(nuevoCliente);
        }
    }
}
