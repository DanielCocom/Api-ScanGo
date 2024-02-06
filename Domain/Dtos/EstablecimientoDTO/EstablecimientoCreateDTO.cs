namespace api_scango.Domain.Dtos;

public class EstablecimientoCreateDTO
{
    
    public string? Nombre { get; set; }

    public string? Imagen { get; set; }


    public string? Direccion { get; set; }

    public decimal? Longitud { get; set; }

    public decimal? Latitud { get; set; }

}