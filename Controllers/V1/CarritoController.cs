// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Threading.Tasks;

// [ApiController]
// [Route("v1/[controller]")]
// public class CarritoController : ControllerBase
// {
//     private readonly CarritoService _carritoService;

//     public CarritoController(CarritoService carritoService)
//     {
//         _carritoService = carritoService;
//     }

//     [HttpPost("AddProducto")]
//     public async Task<IActionResult> AddProducto([FromBody] CarritoAddProducto modelo)
//     {
//         try
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             await _carritoService.AgregarProductoAlCarrito(modelo.Numerodetelefono!, modelo.Codigodebarras!);
//             return Ok(new { message = "Producto agregado al carrito exitosamente" });
//         }
//         catch (Exception ex)
//         {
//             // Loguea el error
//             return StatusCode(500, new { error = "Error interno del servidor", message = ex.Message });
//         }
//     }

//     [HttpGet("Productos")]
//     public async Task<IActionResult> GetProductosCarrito(string numerodetelefono)
//     {
//         try
//         {
//             var productoEnCarrito = await _carritoService.GetProductos(numerodetelefono);
//             return Ok(productoEnCarrito);
//         }
//         catch (Exception ex)
//         {
//             // Loguea el error
//             return StatusCode(500, new { error = "Error interno del servidor", message = ex.Message });
//         }
//     }
// }
