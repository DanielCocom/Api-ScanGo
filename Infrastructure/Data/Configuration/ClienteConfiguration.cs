
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ClientetConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(e => e.Numerodetelefono).HasName("PK__Cliente__F2628ECFF16EC672");

            builder.Property(e => e.Numerodetelefono)
                .ValueGeneratedNever()
                .HasColumnName("numerodetelefono");
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            builder.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK__Cliente__id_carr__3B75D760");
        
    }
}
