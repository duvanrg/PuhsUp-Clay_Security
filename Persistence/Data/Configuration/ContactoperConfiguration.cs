using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ContactoperConfiguration : IEntityTypeConfiguration<Contactoper>
    {
        public void Configure(EntityTypeBuilder<Contactoper> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contactoper");

            builder.HasIndex(e => e.Descripcion, "Descripcion").IsUnique();

            builder.HasIndex(e => e.PersonaId, "PersonaId");

            builder.HasIndex(e => e.TcontactoId, "TContactoId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.Descripcion).HasMaxLength(150);
            builder.Property(e => e.PersonaId).HasColumnType("int(11)");
            builder.Property(e => e.TcontactoId)
                .HasColumnType("int(11)")
                .HasColumnName("TContactoId");

            builder.HasOne(d => d.Persona).WithMany(p => p.Contactopers)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("contactoper_ibfk_1");

            builder.HasOne(d => d.Tcontacto).WithMany(p => p.Contactopers)
                .HasForeignKey(d => d.TcontactoId)
                .HasConstraintName("contactoper_ibfk_2");
        }
    }
}