
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ProductoEnCarritoConfiguration : IEntityTypeConfiguration<ProductoEnCarrito>
{
    public void Configure(EntityTypeBuilder<ProductoEnCarrito> builder)
    {
        builder.ToTable("ProductoEnCarrito");
                   builder.HasKey(e => e.IdProductoEnCarrito).HasName("PK__Producto__E67E560A33B4F003");

            builder.Property(e => e.IdProductoEnCarrito).HasColumnName("id_producto_en_carrito");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Codigodebarras)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigodebarras");
            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.ProductoNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("producto_nombre");
            builder.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.CodigodebarrasNavigation).WithMany(p => p.ProductoEnCarrito)
                .HasForeignKey(d => d.Codigodebarras)
                .HasConstraintName("FK__ProductoE__codig__412EB0B6");

            builder.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.ProductoEnCarrito)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK__ProductoE__id_ca__403A8C7D");

    }
}
