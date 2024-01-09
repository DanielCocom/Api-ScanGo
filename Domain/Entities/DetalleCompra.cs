using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class DetalleCompra
{
    public int IdCompra { get; set; }

    public string Codigodebarras { get; set; } = null!;

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto CodigodebarrasNavigation { get; set; } = null!;

    public virtual Compra IdCompraNavigation { get; set; } = null!;
}
