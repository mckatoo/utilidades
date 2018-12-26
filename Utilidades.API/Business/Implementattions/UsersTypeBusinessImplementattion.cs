using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;
using Utilidades.API.Repository.Generic;

namespace Utilidades.API.Business.Implementattions {
    public class UsersTypeBusinessImplementattion : IUsersTypeBusiness {
        private IRepository<UsersType> _repository;
        public UsersTypeBusinessImplementattion (IRepository<UsersType> repository) {
            _repository = repository;
        }

        public List<UsersType> FindAll () {
            return _repository.FindAll ();
        }
        public UsersType FindById (long id) {
            return _repository.FindById (id);
        }
        public UsersType Create (UsersType type) {
            type.CreatedAt = DateTimeOffset.UtcNow;
            return _repository.Create (type);
        }

        public void Delete (long id) {
            _repository.Delete (id);
        }

        public UsersType Update (UsersType type) {
            type.UpdatedAt = DateTimeOffset.UtcNow;
            return _repository.Update (type);
        }
    }
}