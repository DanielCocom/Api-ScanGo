
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Producto");
                   builder.HasKey(e => e.Codigodebarras).HasName("PK__Producto__FA9C38D8D53DE167");

            builder.Property(e => e.Codigodebarras)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigodebarras");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            builder.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

    }
}
