using api_scango.Domain.Dtos;
using api_scango.Services.Fetures.compra;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_scango.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class CompraController : ControllerBase
{

    private readonly CompraService _compraServices;
    private readonly IMapper _mapper;

    public CompraController(IMapper mapper, CompraService compraServices)
    {
        this._compraServices = compraServices;
        this._mapper = mapper;
    }
    [HttpPost("RealizarCompra")]
    public async Task<IActionResult> RealizarCompra(int idEstablecimiento, string numroTelefono, string idTransaccion)
    {
// 
    //   
            // Lógica para realizar la compra
            // Puedes llamar al método que implementaste en tu servicio o directamente al repositorio
          var venta =  await _compraServices.RealizarCompra(idEstablecimiento, numroTelefono);
// 
            return Ok("Compra realizada exitosamente"); 
    //    
// 
    }
}