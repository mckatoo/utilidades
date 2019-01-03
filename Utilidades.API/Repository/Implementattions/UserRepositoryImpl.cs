using System.Linq;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;

namespace Utilidades.API.Business.Implementattions {
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