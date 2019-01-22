using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.EntityConfig {
    public class UsersMap : IEntityTypeConfiguration<Users> {
        public void Configure (EntityTypeBuilder<Users> builder) {

            builder.ToTable ("users", "utilidades");

            builder.HasIndex (e => e.Email)
                .HasName ("users_email_unique")
                .IsUnique ();

            builder.HasIndex (e => e.UsersTypeId)
                .HasName ("fk_users_users_type1_idx");

            builder.Property (e => e.Id)
                .HasColumnName ("id")
                .HasColumnType ("int(10) unsigned");

            builder.Property (e => e.CreatedAt).HasColumnName ("created_at");

            builder.Property (e => e.Email)
                .IsRequired ()
                .HasColumnName ("email")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.Password)
                .IsRequired ()
                .HasColumnName ("password")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.RememberToken)
                .HasColumnName ("remember_token")
                .HasMaxLength (100)
                .IsUnicode (false);

            builder.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

            builder.Property (e => e.Username)
                .IsRequired ()
                .HasColumnName ("username")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.UsersTypeId)
                .HasColumnName ("users_type_id")
                .HasColumnType ("int(11)");

            builder.HasOne (d => d.UsersType)
                .WithMany (p => p.Users)
                .HasForeignKey (d => d.UsersTypeId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_users_users_type1");

        }
    }
}