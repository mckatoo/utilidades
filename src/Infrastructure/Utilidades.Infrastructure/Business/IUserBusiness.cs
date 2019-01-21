using System.Collections.Generic;
using Utilidades.ApplicationCore.Data.VO;

namespace Utilidades.Infrastructure.Business {
    public interface IUserBusiness {
        UserVO FindById (long id);
        List<UserVO> FindAll ();
        UserVO Create (UserVO user);
        UserVO Update (UserVO user);
        void Delete (long id);
    }
}