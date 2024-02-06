
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class ClientetConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(e => e.NumeroTelefono).HasName("PK__Cliente__E2891F45EC8170C3");

            builder.Property(e => e.NumeroTelefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numero_telefono");
            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            builder.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            builder.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.IdEstablecimiento).HasColumnName("id_establecimiento");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK__Cliente__id_carr__4E88ABD4");

            builder.HasOne(d => d.IdEstablecimientoNavigation).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.IdEstablecimiento)
                .HasConstraintName("FK__Cliente__id_esta__4F7CD00D");

        
    }
}
