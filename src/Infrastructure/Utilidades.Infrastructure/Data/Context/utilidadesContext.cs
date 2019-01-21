using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Data.Context {
    public partial class utilidadesContext : DbContext {

        public IConfiguration _configuration { get; }
        private readonly string _connectionString;

        public utilidadesContext (IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
        }

        public utilidadesContext (DbContextOptions<utilidadesContext> options) : base (options) { }

        public virtual DbSet<Autorizacoes> Autorizacoes { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Setores> Setores { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersType> UsersType { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySQL (_connectionString);
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation ("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Autorizacoes> (entity => {
                entity.ToTable ("autorizacoes", "utilidades");

                entity.HasIndex (e => e.CursosId)
                    .HasName ("fk_autorizacoes_cursos_idx");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(10) unsigned");

                entity.Property (e => e.Aluno)
                    .IsRequired ()
                    .HasColumnName ("aluno")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.CursosId)
                    .HasColumnName ("cursos_id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Data).HasColumnName ("data");

                entity.Property (e => e.Qrcode)
                    .IsRequired ()
                    .HasColumnName ("qrcode")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Ra)
                    .IsRequired ()
                    .HasColumnName ("ra")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

                entity.Property (e => e.Validade).HasColumnName ("validade");

                entity.HasOne (d => d.Cursos)
                    .WithMany (p => p.Autorizacoes)
                    .HasForeignKey (d => d.CursosId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_autorizacoes_cursos");
            });

            modelBuilder.Entity<Cargos> (entity => {
                entity.ToTable ("cargos", "utilidades");

                entity.HasIndex (e => e.SetoresId)
                    .HasName ("fk_cargos_setores1_idx");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Cargo)
                    .IsRequired ()
                    .HasColumnName ("cargo")
                    .HasMaxLength (45)
                    .IsUnicode (false);

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.SetoresId)
                    .HasColumnName ("setores_id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

                entity.HasOne (d => d.Setores)
                    .WithMany (p => p.Cargos)
                    .HasForeignKey (d => d.SetoresId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_cargos_setores1");
            });

            modelBuilder.Entity<Cursos> (entity => {
                entity.ToTable ("cursos", "utilidades");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.Curso)
                    .IsRequired ()
                    .HasColumnName ("curso")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");
            });

            modelBuilder.Entity<Funcionarios> (entity => {
                entity.ToTable ("funcionarios", "utilidades");

                entity.HasIndex (e => e.CargosId)
                    .HasName ("fk_funcionarios_cargos1_idx");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.CargosId)
                    .HasColumnName ("cargos_id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.FilePhoto)
                    .HasColumnName ("file_photo")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Funcional)
                    .IsRequired ()
                    .HasColumnName ("funcional")
                    .HasMaxLength (45)
                    .IsUnicode (false);

                entity.Property (e => e.Nome)
                    .IsRequired ()
                    .HasColumnName ("nome")
                    .HasMaxLength (45)
                    .IsUnicode (false);

                entity.Property (e => e.Rg)
                    .IsRequired ()
                    .HasColumnName ("rg")
                    .HasMaxLength (45)
                    .IsUnicode (false);

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

                entity.HasOne (d => d.Cargos)
                    .WithMany (p => p.Funcionarios)
                    .HasForeignKey (d => d.CargosId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_funcionarios_cargos1");
            });

            modelBuilder.Entity<Setores> (entity => {
                entity.ToTable ("setores", "utilidades");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.Setor)
                    .IsRequired ()
                    .HasColumnName ("setor")
                    .HasMaxLength (60)
                    .IsUnicode (false);

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");
            });

            modelBuilder.Entity<Users> (entity => {
                entity.ToTable ("users", "utilidades");

                entity.HasIndex (e => e.Email)
                    .HasName ("users_email_unique")
                    .IsUnique ();

                entity.HasIndex (e => e.UsersTypeId)
                    .HasName ("fk_users_users_type1_idx");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(10) unsigned");

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.Email)
                    .IsRequired ()
                    .HasColumnName ("email")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Name)
                    .IsRequired ()
                    .HasColumnName ("name")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Password)
                    .IsRequired ()
                    .HasColumnName ("password")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.RememberToken)
                    .HasColumnName ("remember_token")
                    .HasMaxLength (100)
                    .IsUnicode (false);

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");

                entity.Property (e => e.Username)
                    .IsRequired ()
                    .HasColumnName ("username")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.UsersTypeId)
                    .HasColumnName ("users_type_id")
                    .HasColumnType ("int(11)");

                entity.HasOne (d => d.UsersType)
                    .WithMany (p => p.Users)
                    .HasForeignKey (d => d.UsersTypeId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_users_users_type1");
            });

            modelBuilder.Entity<UsersType> (entity => {
                entity.ToTable ("users_type", "utilidades");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.CreatedAt).HasColumnName ("created_at");

                entity.Property (e => e.Description)
                    .IsRequired ()
                    .HasColumnName ("description")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Level)
                    .HasColumnName ("level")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Type)
                    .IsRequired ()
                    .HasColumnName ("type")
                    .HasMaxLength (45)
                    .IsUnicode (false);

                entity.Property (e => e.UpdatedAt).HasColumnName ("updated_at");
            });
        }
    }
}