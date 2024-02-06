using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;

public partial class ProductoDescuento
{
    public int IdProductoDescuento { get; set; }

    public string? IdProducto { get; set; }

    public int? IdDescuento { get; set; }

    public virtual Descuento? IdDescuentoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
