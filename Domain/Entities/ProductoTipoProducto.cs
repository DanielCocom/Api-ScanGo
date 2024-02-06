using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;

public partial class ProductoTipoProducto
{
    public int IdProductoTipoProducto { get; set; }

    public string? IdProducto { get; set; }

    public int? IdTipoProducto { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual TipoProducto? IdTipoProductoNavigation { get; set; }
}
