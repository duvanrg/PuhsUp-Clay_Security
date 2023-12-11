using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipodireccionConfiguration : IEntityTypeConfiguration<Tipodireccion>
    {
        public void Configure(EntityTypeBuilder<Tipodireccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipodireccion");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.Descripcion).HasMaxLength(150);
        }
    }
}