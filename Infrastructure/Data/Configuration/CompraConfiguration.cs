
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Compra");
        builder.HasKey(e => e.IdCompra).HasName("PK__Compra__C4BAA60494F23086");

            builder.Property(e => e.IdCompra).HasColumnName("id_compra");
            builder.Property(e => e.FechaDeCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_de_compra");
            builder.Property(e => e.Numerodetelefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numerodetelefono");
            builder.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");

            builder.HasOne(d => d.NumerodetelefonoNavigation).WithMany(p => p.Compra)
                .HasForeignKey(d => d.Numerodetelefono)
                .HasConstraintName("FK__Compra__numerode__440B1D61");

    }
}
