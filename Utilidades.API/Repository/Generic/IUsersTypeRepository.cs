using System.Collections.Generic;
using Utilidades.API.Model;
using Utilidades.API.Model.Base;

namespace Utilidades.API.Repository.Generic {
    public interface IUsersTypeRepository : IRepository<UsersType> {
        List<UsersType> FindByType (string type);
    }
}