
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class EstablecimientoConfiguration : IEntityTypeConfiguration<Establecimiento>
{
    public void Configure(EntityTypeBuilder<Establecimiento> builder)
    {
        builder.ToTable("Establecimiento");
                 builder.HasKey(e => e.IdEstablecimiento).HasName("PK__Establec__AFEAEA2035F5091D");

            builder.Property(e => e.IdEstablecimiento).HasColumnName("id_establecimiento");
            builder.Property(e => e.Conexion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("conexion");
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            builder.Property(e => e.NombreBaseDatos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreBaseDatos");
            builder.Property(e => e.NombreEstablecimiento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreEstablecimiento");
            builder.Property(e => e.Servidor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("servidor");
            builder.Property(e => e.TipoBaseDatos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipoBaseDatos");
            builder.Property(e => e.UbicacionLatitud)
                .HasColumnType("decimal(10, 8)")
                .HasColumnName("ubicacion_latitud");
            builder.Property(e => e.UbicacionLongitud)
                .HasColumnType("decimal(11, 8)")
                .HasColumnName("ubicacion_longitud");
            builder.Property(e => e.Usuario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario");

    }
}
