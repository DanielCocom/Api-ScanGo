using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class Establecimiento
{
    public int IdEstablecimiento { get; set; }

    public string? Nombre { get; set; }

    public decimal? UbicacionLatitud { get; set; }

    public decimal? UbicacionLongitud { get; set; }

    public string? Imagen { get; set; }

    public string? Conexion { get; set; }
}
