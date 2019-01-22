using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.EntityConfig {
    public class AutorizacoesMap : IEntityTypeConfiguration<Autorizacoes> {
        public void Configure (EntityTypeBuilder<Autorizacoes> builder) {
            builder.ToTable ("autorizacoes", "utilidades");

            builder.HasIndex (e => e.CursosId)
                .HasName ("fk_autorizacoes_cursos_idx");

            builder.Property (e => e.Id)
                .HasColumnName ("id")
                .HasColumnType ("int(10) unsigned");

            builder.Property (e => e.Aluno)
                .IsRequired ()
                .HasColumnName ("aluno")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.CreatedAt).HasColumnName ("created_at");

            builder.Property (e => e.CursosId)
                .HasColumnName ("cursos_id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Data).HasColumnName ("data");

            builder.Property (e => e.Qrcode)
                .IsRequired ()
                .HasColumnName ("qrcode")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.Ra)
                .IsRequired ()
                .HasColumnName ("ra")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

            builder.Property (e => e.Validade).HasColumnName ("validade");

            builder.HasOne (d => d.Cursos)
                .WithMany (p => p.Autorizacoes)
                .HasForeignKey (d => d.CursosId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_autorizacoes_cursos");
        }
    }
}