using System.Collections.Generic;
using Utilidades.API.Data.VO;

namespace Utilidades.API.Business {
    public interface IUsersTypeBusiness {
        UsersTypeVO FindById (long id);
        List<UsersTypeVO> FindAll ();
        List<UsersTypeVO> FindByType (string type);
        UsersTypeVO Create (UsersTypeVO type);
        UsersTypeVO Update (UsersTypeVO type);
        void Delete (long id);
    }
}