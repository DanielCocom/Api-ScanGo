namespace api_scango.Domain.Dtos;

public class ClienteDto{
    public int NumeroTelefonico {get; set;}
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;

}