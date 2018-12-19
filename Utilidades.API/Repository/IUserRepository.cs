using System.Collections.Generic;
using Utilidades.API.Model;

namespace Utilidades.API.Repository {
    public interface IUserRepository {
        User FindById (long id);
        List<User> FindAll ();
        User Create (User user);
        User Update (User user);
        void Delete (User user);
        bool Exists(long? id);
    }
}