using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class Compra
{
    public int IdCompra { get; set; }

    public int? Numerodetelefono { get; set; }

    public DateTime? FechaDeCompra { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompra { get; set; } = new List<DetalleCompra>();

    public virtual Cliente? NumerodetelefonoNavigation { get; set; }
}
