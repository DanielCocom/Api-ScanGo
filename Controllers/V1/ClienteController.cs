using System;
using System.Threading.Tasks;
using api_scango.Domain.Dtos;
using api_scango.Domain.Entities;
using api_scango.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_scango.Controllers
{
    [ApiController]
    [Route("v1/Cliente")]
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
        public async Task<IActionResult> ObtenerClientePorTelefono(string numerodetelefono)
        {
            try
            {
                var cliente = await _clienteService.ObtenerClientePorTelefonoAsync(numerodetelefono);

                if (cliente == null)
                {
                    return NotFound(new { error = "Cliente no encontrado", message = "El cliente no existe." });
                }

                var dto = _mapper.Map<ClienteDto>(cliente);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                // Loguea el error
                return StatusCode(500, new { error = "Error interno del servidor", message = ex.Message });
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarNuevoCliente([FromBody] ClienteCreateDTO nuevoCliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = _mapper.Map<Cliente>(nuevoCliente);
                await _clienteService.RegistrarNuevoClienteAsync(entity);

                var dto = _mapper.Map<ClienteDto>(entity);

                return CreatedAtAction(nameof(ObtenerClientePorTelefono), new { numerodetelefono = entity.Numerodetelefono }, dto);
            }
            catch (Exception ex)
            {
                // Loguea el error
                return StatusCode(500, new { error = "Error interno del servidor", message = ex.Message });
            }
        }

        // Agrega otros endpoints según sea necesario para las operaciones CRUD
    }
}
