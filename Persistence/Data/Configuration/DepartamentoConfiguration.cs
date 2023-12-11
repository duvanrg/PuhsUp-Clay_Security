using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("departamento");

            builder.HasIndex(e => e.PaisId, "PaisId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.NombreDep).HasMaxLength(50);
            builder.Property(e => e.PaisId).HasColumnType("int(11)");

            builder.HasOne(d => d.Pais).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("departamento_ibfk_2");
        }
    }
}