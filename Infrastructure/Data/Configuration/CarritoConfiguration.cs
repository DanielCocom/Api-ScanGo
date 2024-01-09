
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
{
    public void Configure(EntityTypeBuilder<Carrito> builder)
    {
        builder.ToTable("Carrito");
        builder.HasKey(e => e.IdCarrito).HasName("PK__Carrito__83A2AD9C73DE8384");

        builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
        builder.Property(e => e.TotalAPagar)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("total_a_pagar");
        builder.Property(e => e.TotalDeArticulo).HasColumnName("total_de_articulo");

    }
}
