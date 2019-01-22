using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Data.EntityConfig;

namespace Utilidades.Infrastructure.Data.Context {
    public partial class utilidadesContext : DbContext {

        // public IConfiguration _configuration { get; }
        // private readonly string _connectionString;

        // public utilidadesContext (IConfiguration configuration) {
        //     _configuration = configuration;
        //     _connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
        // }

        public utilidadesContext (DbContextOptions<utilidadesContext> options) : base (options) { }

        public virtual DbSet<Autorizacoes> Autorizacoes { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Setores> Setores { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersType> UsersType { get; set; }

        // protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
        //     if (!optionsBuilder.IsConfigured) {
        //         optionsBuilder.UseMySQL (_connectionString);
        //     }
        // }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation ("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.ApplyConfiguration (new AutorizacoesMap ());
            modelBuilder.ApplyConfiguration (new CargosMap ());
            modelBuilder.ApplyConfiguration (new CursosMap ());
            modelBuilder.ApplyConfiguration (new FuncionariosMap ());
            modelBuilder.ApplyConfiguration (new SetoresMap ());
            modelBuilder.ApplyConfiguration (new UsersMap ());
            modelBuilder.ApplyConfiguration (new UsersTypeMap ());

        }
    }
}