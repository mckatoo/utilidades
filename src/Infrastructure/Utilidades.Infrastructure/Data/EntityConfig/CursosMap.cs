using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.EntityConfig {
    public class CursosMap : IEntityTypeConfiguration<Cursos> {
        public void Configure (EntityTypeBuilder<Cursos> builder) {

            builder.ToTable ("cursos", "utilidades");

            builder.Property (e => e.Id)
                .HasColumnName ("id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.CreatedAt).HasColumnName ("created_at");

            builder.Property (e => e.Curso)
                .IsRequired ()
                .HasColumnName ("curso")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

        }
    }
}