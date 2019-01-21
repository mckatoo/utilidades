using System.Collections.Generic;
using Utilidades.ApplicationCore.Model;

namespace Utilidades.Infrastructure.Repository.Generic {
    public interface IUsersTypeRepository : IRepository<UsersType> {
        List<UsersType> FindByType (string type);
    }
}