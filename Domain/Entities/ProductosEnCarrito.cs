using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;

public partial class ProductosEnCarrito
{
    public int IdProductoEncarrito { get; set; }

    public string? IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();

    public virtual Producto? IdProductoNavigation { get; set; }
}
