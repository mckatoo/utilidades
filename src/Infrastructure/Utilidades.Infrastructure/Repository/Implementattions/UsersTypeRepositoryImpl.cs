using System.Collections.Generic;
using System.Linq;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Data.Context;
using Utilidades.Infrastructure.Repository;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Business.Implementattions {
    public class UsersTypeRepositoryImpl : GenericRepository<UsersType>, IUsersTypeRepository {
        public UsersTypeRepositoryImpl (utilidadesContext context) : base (context) { }

        public List<UsersType> FindByType (string type) {
            if (string.IsNullOrWhiteSpace (type))
                return _context.UsersType.ToList ();
            return _context.UsersType.Where (t => t.Type.Contains (type)).ToList ();
        }
    }
}