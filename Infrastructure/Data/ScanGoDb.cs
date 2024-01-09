using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using api_scango.Domain.Entities;
using api_scango.Infrastructure.Data.Configurations;
namespace api_scango.Infrastructure.Data;

public partial class ScanGoDb : DbContext
{
    public ScanGoDb()
    {
    }

    public ScanGoDb(DbContextOptions<ScanGoDb> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carrito { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Compra> Compra { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }

    public virtual DbSet<Establecimiento> Establecimiento { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<ProductoEnCarrito> ProductoEnCarrito { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlServer("Name=ConnectionStrings:gemDevelopment");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.ApplyConfiguration(new ProductoEnCrritoConfiguration());
        modelBuilder.ApplyConfiguration(new ClientetConfiguration());
        modelBuilder.ApplyConfiguration(new CarritoConfiguration());
        modelBuilder.ApplyConfiguration(new DetalleCompraConfiguration());
        modelBuilder.ApplyConfiguration(new EstablecimientoConfiguration());
        modelBuilder.ApplyConfiguration(new CompraConfiguration());
        modelBuilder.ApplyConfiguration(new ProductoConfiguration());





        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
