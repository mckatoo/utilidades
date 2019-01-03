using Microsoft.EntityFrameworkCore;

namespace Utilidades.API.Model.Context {
    public class MySQLContext : DbContext {
        public MySQLContext () { }
        public MySQLContext (DbContextOptions<MySQLContext> options) : base (options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersType> UsersTypes { get; set; }
    }
}