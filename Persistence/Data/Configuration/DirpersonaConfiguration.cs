using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DirpersonaConfiguration : IEntityTypeConfiguration<Dirpersona>
    {
        public void Configure(EntityTypeBuilder<Dirpersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("dirpersona");

            builder.HasIndex(e => e.PersonaId, "PersonaId");

            builder.HasIndex(e => e.TdireccionId, "TDireccionId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.Direccion).HasMaxLength(80);
            builder.Property(e => e.PersonaId).HasColumnType("int(11)");
            builder.Property(e => e.TdireccionId)
                .HasColumnType("int(11)")
                .HasColumnName("TDireccionId");

            builder.HasOne(d => d.Persona).WithMany(p => p.Dirpersonas)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("dirpersona_ibfk_1");

            builder.HasOne(d => d.Tdireccion).WithMany(p => p.Dirpersonas)
                .HasForeignKey(d => d.TdireccionId)
                .HasConstraintName("dirpersona_ibfk_2");
        }
    }
}