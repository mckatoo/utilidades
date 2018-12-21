using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;

namespace Utilidades.API.Business.Implementattions {
    public class UserBusinessImplementattion : IUserBusiness {
        private IUserRepository _repository;
        public UserBusinessImplementattion (IUserRepository repository) {
            _repository = repository;
        }

        public List<User> FindAll () {
            return _repository.FindAll();
        }
        public User FindById (long id) {
            return _repository.FindById(id);
        }
        public User Create (User user) {
            return _repository.Create(user);
        }

        public void Delete (User user) {
            _repository.Delete(user);
        }

        public User Update (User user) {
            return _repository.Update(user);
        }
    }
}