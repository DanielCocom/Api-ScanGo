
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ProductoEnCarritoConfiguration : IEntityTypeConfiguration<ProductosEnCarrito>
{
    public void Configure(EntityTypeBuilder<ProductosEnCarrito> builder)
    {
        builder.ToTable("ProductosEnCarrito");
                    builder.HasKey(e => e.IdProductoEncarrito).HasName("PK__Producto__65992ACED16B4394");

            builder.Property(e => e.IdProductoEncarrito)
                .ValueGeneratedNever()
                .HasColumnName("id_productoEncarrito");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_producto");
            builder.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            builder.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductosEnCarrito)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Productos__id_pr__48CFD27E");


    }
}
