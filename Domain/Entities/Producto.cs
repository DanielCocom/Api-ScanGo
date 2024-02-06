using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;

public partial class Producto
{
    public string IdProducto { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Imagen { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? IdTipoProducto { get; set; }

    public virtual ICollection<CompraDetalles> CompraDetalles { get; set; } = new List<CompraDetalles>();

    public virtual TipoProducto? IdTipoProductoNavigation { get; set; }

    public virtual ICollection<ProductoDescuento> ProductoDescuento { get; set; } = new List<ProductoDescuento>();

    public virtual ICollection<ProductoInventario> ProductoInventario { get; set; } = new List<ProductoInventario>();

    public virtual ICollection<ProductoTipoProducto> ProductoTipoProducto { get; set; } = new List<ProductoTipoProducto>();

    public virtual ICollection<ProductosEnCarrito> ProductosEnCarrito { get; set; } = new List<ProductosEnCarrito>();
}
