using Microsoft.AspNetCore.Mvc;
using api_scango.Domain.Entities;
using api_scango.Services.Fetures.producto;
using AutoMapper;
using api_scango.Domain;

namespace api_scango.Controller.V1;
[ApiController]
[Route("ScanGo/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductoService _productoService;
    // mapper 

    public ProductoController(ProductoService productoService)
    {
        this._productoService = productoService;

    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var producto = await _productoService.GetAllProductos();

        return Ok(producto);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(string id)
    {
        var producto  = await _productoService.GetById(id);
        if(producto.Codigodebarras == null){
            return NotFound("No se encontro el Producto");
        }
        // agregar dto

        return Ok(producto);


    }
}