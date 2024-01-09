﻿using System;
using System.Collections.Generic;

namespace api_scango.Domain.Entities;


public partial class Cliente
{
    public int Numerodetelefono { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int? IdCarrito { get; set; }

    public virtual ICollection<Compra> Compra { get; set; } = new List<Compra>();

    public virtual Carrito? IdCarritoNavigation { get; set; }
}
