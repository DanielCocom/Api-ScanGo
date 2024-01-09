
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class DetalleCompraConfiguration : IEntityTypeConfiguration<DetalleCompra>
{
    public void Configure(EntityTypeBuilder<DetalleCompra> builder)
    {
        builder.ToTable("DetalleCompra");
                    builder.HasKey(e => new { e.IdCompra, e.Codigodebarras }).HasName("PK__DetalleC__5B1365892C4D0D66");

            builder.Property(e => e.IdCompra).HasColumnName("id_compra");
            builder.Property(e => e.Codigodebarras)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigodebarras");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.CodigodebarrasNavigation).WithMany(p => p.DetalleCompra)
                .HasForeignKey(d => d.Codigodebarras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__codig__47DBAE45");

            builder.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompra)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__id_co__46E78A0C");

    }
}
