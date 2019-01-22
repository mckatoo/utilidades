using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.EntityConfig {
    public class FuncionariosMap : IEntityTypeConfiguration<Funcionarios> {
        public void Configure (EntityTypeBuilder<Funcionarios> builder) {

            builder.ToTable ("funcionarios", "utilidades");

            builder.HasIndex (e => e.CargosId)
                .HasName ("fk_funcionarios_cargos1_idx");

            builder.Property (e => e.Id)
                .HasColumnName ("id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.CargosId)
                .HasColumnName ("cargos_id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.CreatedAt).HasColumnName ("created_at");

            builder.Property (e => e.FilePhoto)
                .HasColumnName ("file_photo")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.Funcional)
                .IsRequired ()
                .HasColumnName ("funcional")
                .HasMaxLength (45)
                .IsUnicode (false);

            builder.Property (e => e.Nome)
                .IsRequired ()
                .HasColumnName ("nome")
                .HasMaxLength (45)
                .IsUnicode (false);

            builder.Property (e => e.Rg)
                .IsRequired ()
                .HasColumnName ("rg")
                .HasMaxLength (45)
                .IsUnicode (false);

            builder.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

            builder.HasOne (d => d.Cargos)
                .WithMany (p => p.Funcionarios)
                .HasForeignKey (d => d.CargosId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_funcionarios_cargos1");

        }
    }
}