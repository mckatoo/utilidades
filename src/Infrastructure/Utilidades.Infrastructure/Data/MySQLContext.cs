using Microsoft.EntityFrameworkCore;
using Utilidades.ApplicationCore.Model;

namespace Utilidades.Infrastructure.Data {
    public class MySQLContext : DbContext {
        public MySQLContext () { }
        public MySQLContext (DbContextOptions<MySQLContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersType> UsersTypes { get; set; }
    }
}