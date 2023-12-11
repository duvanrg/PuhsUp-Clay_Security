using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CategoriaperConfiguration :IEntityTypeConfiguration<Categoriaper>
    {
        public void Configure(EntityTypeBuilder<Categoriaper> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("categoriaper");

            builder.Property(e => e.Id).HasColumnType("int(11)");
            builder.Property(e => e.NombreCat).HasMaxLength(30);
        }
    }
}