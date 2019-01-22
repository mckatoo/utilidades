using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.EntityConfig {
    public class CargosMap : IEntityTypeConfiguration<Cargos> {
        public void Configure (EntityTypeBuilder<Cargos> builder) {
            builder.ToTable ("cargos", "utilidades");

            builder.HasIndex (e => e.SetoresId)
                .HasName ("fk_cargos_setores1_idx");

            builder.Property (e => e.Id)
                .HasColumnName ("id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Cargo)
                .IsRequired ()
                .HasColumnName ("cargo")
                .HasMaxLength (45)
                .IsUnicode (false);

            builder.Property (e => e.CreatedAt).HasColumnName ("created_at");

            builder.Property (e => e.SetoresId)
                .HasColumnName ("setores_id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

            builder.HasOne (d => d.Setores)
                .WithMany (p => p.Cargos)
                .HasForeignKey (d => d.SetoresId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_cargos_setores1");
        }
    }
}