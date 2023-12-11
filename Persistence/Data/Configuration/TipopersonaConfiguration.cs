using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipopersonaConfiguration : IEntityTypeConfiguration<Tipopersona>
    {
        public void Configure(EntityTypeBuilder<Tipopersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipopersona");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.Descripcion).HasMaxLength(150);
        }
    }
}