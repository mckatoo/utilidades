using System.Collections.Generic;
using System.Linq;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;
using Utilidades.API.Repository.Generic;

namespace Utilidades.API.Business.Implementattions {
    public class UsersTypeRepositoryImpl : GenericRepository<UsersType>, IUsersTypeRepository {
        public UsersTypeRepositoryImpl (MySQLContext context) : base (context) { }

        public List<UsersType> FindByType (string type) {
            if (string.IsNullOrWhiteSpace (type))
                return _context.UsersTypes.ToList ();
            return _context.UsersTypes.Where (t => t.Type.Contains (type)).ToList ();
        }
    }
}