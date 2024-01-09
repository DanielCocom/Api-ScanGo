
using api_scango.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_scango.Infrastructure.Data.Configurations;

public class EstablecimientoConfiguration : IEntityTypeConfiguration<Establecimiento>
{
    public void Configure(EntityTypeBuilder<Establecimiento> builder)
    {
        builder.ToTable("Establecimiento");
                    builder.HasKey(e => e.IdEstablecimiento).HasName("PK__Establec__AFEAEA2076EEB3DD");

            builder.Property(e => e.IdEstablecimiento).HasColumnName("id_establecimiento");
            builder.Property(e => e.Conexion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("conexion");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            builder.Property(e => e.UbicacionLatitud)
                .HasColumnType("decimal(10, 8)")
                .HasColumnName("ubicacion_latitud");
            builder.Property(e => e.UbicacionLongitud)
                .HasColumnType("decimal(11, 8)")
                .HasColumnName("ubicacion_longitud");

    }
}
