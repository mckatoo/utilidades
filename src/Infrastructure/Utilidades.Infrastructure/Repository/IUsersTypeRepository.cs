using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Repository {
    public interface IUsersTypeRepository : IRepository<UsersType> {
        List<UsersType> FindByType (string type);
    }
}