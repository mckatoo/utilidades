using System.Collections.Generic;
using System.Linq;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Data.Context;
using Utilidades.Infrastructure.Repository;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Business.Implementattions {
    // public class UserRepositoryImpl : IUserRepository {
    //     private readonly utilidadesContext _context;
    //     public UserRepositoryImpl (utilidadesContext context) {
    //         _context = context;
    //     }

    //     public Users FindByLogin (string login) {
    //         return _context.Users.SingleOrDefault (u => u.Username.Equals (login));
    //     }

    //     public List<Users> FindByName(string name)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }

    public class UserRepositoryImpl : GenericRepository<Users>, IUserRepository {
        public UserRepositoryImpl (utilidadesContext context) : base (context) { }

        public Users FindByLogin (string login) {
            return _context.Users.SingleOrDefault (u => u.Username.Equals (login));
        }

        public List<Users> FindByName (string name) {
            if (string.IsNullOrWhiteSpace (name))
                return _context.Users.ToList ();
            return _context.Users.Where (t => t.Name.Contains (name)).ToList ();
        }
    }
}