using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class Carrito
{
    public int IdCarrito { get; set; }

    public int? TotalDeArticulo { get; set; }

    public decimal? TotalAPagar { get; set; }

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    public virtual ICollection<ProductoEnCarrito> ProductoEnCarrito { get; set; } = new List<ProductoEnCarrito>();
}
