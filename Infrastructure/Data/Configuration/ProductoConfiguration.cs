
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        
       builder.ToTable("Producto");
                   builder.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0DFE963F37");

            builder.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_producto");
            builder.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            builder.Property(e => e.IdTipoProducto).HasColumnName("id_tipo_producto");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            builder.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            builder.HasOne(d => d.IdTipoProductoNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdTipoProducto)
                .HasConstraintName("FK__Producto__id_tip__398D8EEE");

    }
}
