using System.Linq;
using Utilidades.ApplicationCore.Model;
using Utilidades.Infrastructure.Data;
using Utilidades.Infrastructure.Repository;

namespace Utilidades.Infrastructure.Business.Implementattions {
    public class UserRepositoryImpl : IUserRepository {
        private readonly MySQLContext _context;
        public UserRepositoryImpl (MySQLContext context) {
            _context = context;
        }

        public User FindByLogin (string login) {
            return _context.Users.SingleOrDefault (u => u.Username.Equals (login));
        }

    }
}