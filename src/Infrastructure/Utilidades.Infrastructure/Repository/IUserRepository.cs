using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Repository {
    public interface IUserRepository : IRepository<Users> {
        Users FindByLogin (string login);
        List<Users> FindByName (string name);
    }
}