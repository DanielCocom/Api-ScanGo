using Microsoft.AspNetCore.Mvc;
using api_scango.Domain.Entities;
using AutoMapper;
using api_scango.Domain.Dtos;
using System;
using System.Threading.Tasks;
using api_scango.Services.Fetures.producto;

namespace api_scango.Controllers.V1
{
    [ApiController]
    [Route("ScanGo/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(ProductoService productoService, IMapper mapper)
        {
            _productoService = productoService ?? throw new ArgumentNullException(nameof(productoService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var productos = await _productoService.GetAllProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var producto = await _productoService.GetById(id);
                if (producto.Codigodebarras == null)
                {
                    return NotFound(new { error = "Producto no encontrado", message = "No se encontró el Producto" });
                }

                var dto = _mapper.Map<ProductoDto>(producto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductoCreateDto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { error = "Invalid Model", message = "El modelo proporcionado no es válido" });
                }

                var entity = _mapper.Map<Producto>(producto);
                await _productoService.Add(entity);
                var dto = _mapper.Map<ProductoDto>(entity);

                return CreatedAtAction(nameof(GetById), new { id = entity.Codigodebarras }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
        }
    }
}
