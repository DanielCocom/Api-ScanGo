
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class ProductoInventariorConfiguration : IEntityTypeConfiguration<ProductoInventario>
{
    public void Configure(EntityTypeBuilder<ProductoInventario> builder)

    {
        builder.ToTable("ProductoInventario");
        builder.HasKey(e => e.IdProductoInventario).HasName("PK__Producto__7362DAA5584AAE58");

            builder.Property(e => e.IdProductoInventario).HasColumnName("id_producto_inventario");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_producto");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoInventario)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__ProductoI__id_pr__3C69FB99");
    }
}