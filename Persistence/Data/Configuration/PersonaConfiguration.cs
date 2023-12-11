using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persona");

            builder.HasIndex(e => e.CatId, "CatId");

            builder.HasIndex(e => e.CiudadId, "CiudadId");

            builder.HasIndex(e => e.IdPersona, "IdPersona").IsUnique();

            builder.HasIndex(e => new { e.TpersonaId, e.CatId, e.CiudadId }, "TPersonaId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.CatId).HasColumnType("int(11)");
            builder.Property(e => e.CiudadId).HasColumnType("int(11)");
            builder.Property(e => e.IdPersona).HasColumnType("int(11)");
            builder.Property(e => e.Nombre).HasMaxLength(50);
            builder.Property(e => e.TpersonaId)
                .HasColumnType("int(11)")
                .HasColumnName("TPersonaId");

            builder.HasOne(d => d.Cat).WithMany(p => p.Personas)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("persona_ibfk_4");

            builder.HasOne(d => d.Ciudad).WithMany(p => p.Personas)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("persona_ibfk_2");

            builder.HasOne(d => d.Tpersona).WithMany(p => p.Personas)
                .HasForeignKey(d => d.TpersonaId)
                .HasConstraintName("persona_ibfk_3");
        }
    }
}