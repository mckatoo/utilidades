using System.Linq;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Data.Context;
using Utilidades.Infrastructure.Repository;

namespace Utilidades.Infrastructure.Business.Implementattions {
    public class UserRepositoryImpl : IUserRepository {
        private readonly utilidadesContext _context;
        public UserRepositoryImpl (utilidadesContext context) {
            _context = context;
        }

        public Users FindByLogin (string login) {
            return _context.Users.SingleOrDefault (u => u.Username.Equals (login));
        }

    }
}