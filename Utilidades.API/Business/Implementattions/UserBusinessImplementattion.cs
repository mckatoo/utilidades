using System;
using System.Collections.Generic;
using Utilidades.API.Data.Converters;
using Utilidades.API.Data.VO;
using Utilidades.API.Model;
using Utilidades.API.Repository.Generic;

namespace Utilidades.API.Business.Implementattions {
    public class UserBusinessImplementattion : IUserBusiness {
        private IRepository<User> _repository;
        private readonly UserConverter _converter;
        public UserBusinessImplementattion (IRepository<User> repository) {
            _repository = repository;
            _converter = new UserConverter ();
        }

        public List<UserVO> FindAll () {
            return _converter.ParseList (_repository.FindAll ());
        }
        public UserVO FindById (long id) {
            return _converter.Parse (_repository.FindById (id));
        }
        public UserVO Create (UserVO user) {
            user.CreatedAt = DateTimeOffset.UtcNow;

            var userEntity = _converter.Parse (user);
            userEntity = _repository.Create (userEntity);

            return _converter.Parse (userEntity);
        }

        public void Delete (long id) {
            _repository.Delete (id);
        }

        public UserVO Update (UserVO user) {
            user.UpdatedAt = DateTimeOffset.UtcNow;

            var userEntity = _converter.Parse (user);
            userEntity = _repository.Update (userEntity);

            return _converter.Parse (userEntity);
        }
    }
}