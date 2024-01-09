
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ProductoEnCrritoConfiguration : IEntityTypeConfiguration<ProductoEnCarrito>
{
    public void Configure(EntityTypeBuilder<ProductoEnCarrito> builder)
    {
        builder.ToTable("ProductoEnCarrito");
                    builder.HasKey(e => new { e.IdCarrito, e.Codigodebarras }).HasName("PK__Producto__1C0B6E111DA83C56");

            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.Codigodebarras)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigodebarras");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.CodigodebarrasNavigation).WithMany(p => p.ProductoEnCarrito)
                .HasForeignKey(d => d.Codigodebarras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoE__codig__412EB0B6");

            builder.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.ProductoEnCarrito)
                .HasForeignKey(d => d.IdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoE__id_ca__403A8C7D");

    }
}
