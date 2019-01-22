using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.EntityConfig {
    public class UsersTypeMap : IEntityTypeConfiguration<UsersType> {
        public void Configure (EntityTypeBuilder<UsersType> builder) {

            builder.ToTable ("users_type", "utilidades");

            builder.Property (e => e.Id)
                .HasColumnName ("id")
                .HasColumnType ("int(11)");

            builder.Property (e => e.CreatedAt).HasColumnName ("created_at");

            builder.Property (e => e.Description)
                .IsRequired ()
                .HasColumnName ("description")
                .HasMaxLength (255)
                .IsUnicode (false);

            builder.Property (e => e.Level)
                .HasColumnName ("level")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasMaxLength (45)
                .IsUnicode (false);

            builder.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

        }
    }
}