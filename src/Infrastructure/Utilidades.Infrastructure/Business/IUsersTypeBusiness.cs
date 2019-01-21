using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using Utilidades.ApplicationCore.Data.VO;

namespace Utilidades.Infrastructure.Business {
    public interface IUsersTypeBusiness {
        UsersTypeVO FindById (long id);
        List<UsersTypeVO> FindAll ();
        List<UsersTypeVO> FindByType (string type);
        UsersTypeVO Create (UsersTypeVO type);
        UsersTypeVO Update (UsersTypeVO type);
        void Delete (long id);
        PagedSearchDTO<UsersTypeVO> FindWithPagedSearch (string name, string sortDirection, int pageSize, int page);
    }
}