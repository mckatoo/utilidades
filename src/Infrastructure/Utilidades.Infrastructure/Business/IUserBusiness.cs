using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using Utilidades.ApplicationCore.Data.VO;

namespace Utilidades.Infrastructure.Business {
    public interface IUserBusiness {
        UserVO FindById (long id);
        List<UserVO> FindAll ();
        List<UserVO> FindByName (string name);
        UserVO Create (UserVO user);
        UserVO Update (UserVO user);
        void Delete (long id);
        PagedSearchDTO<UserVO> FindWithPagedSearch (string name, string sortDirection, int pageSize, int activePage);
    }
}