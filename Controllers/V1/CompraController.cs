using api_scango.Domain.Dtos;
using api_scango.Services.Fetures.compra;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_scango.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class CommpraController : ControllerBase{

    private readonly CompraServices _compraServices;
    private readonly IMapper _mapper;

    public CommpraController(IMapper mapper, CompraServices compraServices){
        this._compraServices = compraServices;
        this._mapper = mapper;
    }
    [HttpGet("vaciae")]
    public async Task<ActionResult> Comprar(string numero){
        await _compraServices.RealizarCompra(numero);
        return Ok("La compra se ha realizado");
    }
}