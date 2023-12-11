using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contrato");

            builder.HasIndex(e => e.ClienteId, "ClienteId");

            builder.HasIndex(e => e.EmpleadoId, "EmpleadoId");

            builder.HasIndex(e => e.EstatoId, "EstatoId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.ClienteId).HasColumnType("int(11)");
            builder.Property(e => e.EmpleadoId).HasColumnType("int(11)");
            builder.Property(e => e.EstatoId).HasColumnType("int(11)");

            builder.HasOne(d => d.Cliente).WithMany(p => p.ContratoClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("contrato_ibfk_1");

            builder.HasOne(d => d.Empleado).WithMany(p => p.ContratoEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("contrato_ibfk_2");

            builder.HasOne(d => d.Estato).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.EstatoId)
                .HasConstraintName("contrato_ibfk_3");
        }
    }
}