using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_scango.Domain.Entities;

public partial class Establecimiento
{
    
    public int IdEstablecimiento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Imagen { get; set; }

    public int? IdInventario { get; set; }

    public string? Direccion { get; set; }

    public decimal? Longitud { get; set; }

    public decimal? Latitud { get; set; }

    public virtual ICollection<Administrador> Administrador { get; set; } = new List<Administrador>();

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    public virtual Inventario? IdInventarioNavigation { get; set; }
}
