using System.Threading.Tasks;
using api_scango.Domain.Dtos;
using api_scango.Domain.Entities;
using api_scango.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_scango.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        
        private readonly ClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(ClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet("{numerodetelefono}")]
        public async Task<IActionResult> ObtenerClientePorTelefono(int numerodetelefono)
        {
            var cliente = await _clienteService.ObtenerClientePorTelefonoAsync(numerodetelefono);

            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            var dto = _mapper.Map<ClienteDto>(cliente);

            return Ok(dto);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarNuevoCliente(ClienteCreateDTO nuevoCliente)
        {
            var entity = _mapper.Map<Cliente>(nuevoCliente);
            // FIXME: H

            // considerar si ya existe el cliente
            await _clienteService.RegistrarNuevoClienteAsync(entity);

            var dto = _mapper.Map<ClienteDto>(entity);
            // return CreatedAtAction(nameof(RegistrarNuevoCliente), new { numero = entity.Numerodetelefono });
            return Ok("Creacion de Cuenta Exitosa");

        }

        // Agrega otros endpoints según sea necesario para las operaciones CRUD
    }
}
