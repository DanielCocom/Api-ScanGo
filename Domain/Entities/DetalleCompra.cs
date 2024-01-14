using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int? IdCompra { get; set; }

    public string? Codigodebarras { get; set; }

    public string? ProductoNombre { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? CodigodebarrasNavigation { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }
}
