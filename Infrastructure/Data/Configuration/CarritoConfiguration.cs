
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
{
    public void Configure(EntityTypeBuilder<Carrito> builder)
    {
        builder.ToTable("Carrito");
        builder.HasKey(e => e.IdCarrito).HasName("PK__Carrito__83A2AD9C3104B995");

        builder.Property(e => e.IdCarrito)
            .ValueGeneratedOnAdd()
            .HasColumnName("id_carrito");
        builder.Property(e => e.IdProductoCarrito).HasColumnName("id_producto_carrito");
        builder.Property(e => e.TotalArticulos).HasColumnName("total_articulos");
        builder.Property(e => e.TotalPagar)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("total_pagar");

        builder.HasOne(d => d.IdProductoCarritoNavigation).WithMany(p => p.Carrito)
            .HasForeignKey(d => d.IdProductoCarrito)
            .HasConstraintName("FK__Carrito__id_prod__4BAC3F29");


    }
}
