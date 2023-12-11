using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("ciudad");

            builder.HasIndex(e => e.DepId, "DepId");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.DepId).HasColumnType("int(11)");
            builder.Property(e => e.NombreCiu).HasMaxLength(50);

            builder.HasOne(d => d.Dep).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.DepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ciudad_ibfk_1");
        }
    }
}