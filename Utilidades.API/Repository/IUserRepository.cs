using System.Collections.Generic;
using Utilidades.API.Model;

namespace Utilidades.API.Business {
    public interface IUserRepository {
        Login FindByLogin (string login);
    }
}