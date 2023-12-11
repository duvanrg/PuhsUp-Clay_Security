using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("programacion");

            builder.HasIndex(e => e.ContratoId, "ContratoId");

            builder.HasIndex(e => e.EmpleadoId, "EmpleadoId");

            builder.HasIndex(e => e.TurnoId, "TurnoId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.ContratoId).HasColumnType("int(11)");
            builder.Property(e => e.EmpleadoId).HasColumnType("int(11)");
            builder.Property(e => e.TurnoId).HasColumnType("int(11)");

            builder.HasOne(d => d.Contrato).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.ContratoId)
                .HasConstraintName("programacion_ibfk_2");

            builder.HasOne(d => d.Empleado).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("programacion_ibfk_1");

            builder.HasOne(d => d.Turno).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.TurnoId)
                .HasConstraintName("programacion_ibfk_3");
        }
    }
}