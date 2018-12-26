using System.Collections.Generic;
using Utilidades.API.Model;

namespace Utilidades.API.Business {
    public interface IUsersTypeBusiness {
        UsersType FindById (long id);
        List<UsersType> FindAll ();
        UsersType Create (UsersType type);
        UsersType Update (UsersType type);
        void Delete (long id);
    }
}