using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class Establecimiento
{
    public int IdEstablecimiento { get; set; }

    public string? NombreEstablecimiento { get; set; }

    public string? Servidor { get; set; }

    public string? NombreBaseDatos { get; set; }

    public string? Usuario { get; set; }

    public string? Contraseña { get; set; }

    public string? TipoBaseDatos { get; set; }

    public decimal? UbicacionLatitud { get; set; }

    public decimal? UbicacionLongitud { get; set; }

    public string? Imagen { get; set; }

    public string? Conexion { get; set; }
}
