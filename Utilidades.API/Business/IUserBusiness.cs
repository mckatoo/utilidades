using System.Collections.Generic;
using Utilidades.API.Data.VO;

namespace Utilidades.API.Business {
    public interface IUserBusiness {
        UserVO FindById (long id);
        List<UserVO> FindAll ();
        UserVO Create (UserVO user);
        UserVO Update (UserVO user);
        void Delete (long id);
    }
}