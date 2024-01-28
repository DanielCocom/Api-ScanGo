namespace api_scango.Domain.Dtos;

public class EstablecimientoDTO
{
    public int? idSuper {get; set;}
    public string? NombreEstablecimiento { get; set; }

    public string? Servidor { get; set; }

    public string? NombreBaseDatos { get; set; }

    public string? Usuario { get; set; }

    public string? Contraseña { get; set; }

}