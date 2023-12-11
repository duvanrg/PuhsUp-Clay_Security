using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipocontactoConfiguration : IEntityTypeConfiguration<Tipocontacto>
    {
        public void Configure(EntityTypeBuilder<Tipocontacto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipocontacto");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.Descripcion).HasMaxLength(150);
        }
    }
}