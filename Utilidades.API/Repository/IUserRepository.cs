using System.Collections.Generic;
using Utilidades.API.Model;

namespace Utilidades.API.Business {
    public interface IUserRepository {
        User FindByLogin (string login);
    }
}