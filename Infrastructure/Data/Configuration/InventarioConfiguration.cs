using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;


public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("Inventario");
        builder.HasKey(e => e.IdInventario).HasName("PK__Inventar__013AEB5131C2A297");

            builder.Property(e => e.IdInventario).HasColumnName("id_inventario")
            .ValueGeneratedOnAdd();
            builder.Property(e => e.IdProductoInventario).HasColumnName("id_producto_inventario");

            builder.HasOne(d => d.IdProductoInventarioNavigation).WithMany(p => p.Inventario)
                .HasForeignKey(d => d.IdProductoInventario)
                .HasConstraintName("FK__Inventari__id_pr__3F466844");
    } 
}