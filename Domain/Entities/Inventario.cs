using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int? IdProductoInventario { get; set; }

    public virtual ICollection<Establecimiento> Establecimiento { get; set; } = new List<Establecimiento>();

    public virtual ProductoInventario? IdProductoInventarioNavigation { get; set; }
}
