namespace api_scango.Domain.Dtos;
public  class ClienteCreateDTO
{
    public int Numerodetelefono { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
}