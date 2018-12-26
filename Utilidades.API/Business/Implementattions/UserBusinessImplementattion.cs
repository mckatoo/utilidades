using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;
using Utilidades.API.Repository.Generic;

namespace Utilidades.API.Business.Implementattions {
    public class UserBusinessImplementattion : IUserBusiness {
        private IRepository<User> _repository;
        public UserBusinessImplementattion (IRepository<User> repository) {
            _repository = repository;
        }

        public List<User> FindAll () {
            return _repository.FindAll ();
        }
        public User FindById (long id) {
            return _repository.FindById (id);
        }
        public User Create (User user) {
            user.CreatedAt = DateTimeOffset.UtcNow;
            return _repository.Create (user);
        }

        public void Delete (long id) {
            _repository.Delete (id);
        }

        public User Update (User user) {
            user.UpdatedAt = DateTimeOffset.UtcNow;
            return _repository.Update (user);
        }
    }
}