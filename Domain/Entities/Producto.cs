using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class Producto
{
    public string Codigodebarras { get; set; } = null!;

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompra { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<ProductoEnCarrito> ProductoEnCarrito { get; set; } = new List<ProductoEnCarrito>();
}
