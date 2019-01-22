using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Data.Converters;
using Utilidades.ApplicationCore.Data.VO;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Business.Implementattions {
    public class UserBusinessImpl : IUserBusiness {
        private IRepository<Users> _repository;
        private readonly UserConverter _converter;
        public UserBusinessImpl (IRepository<Users> repository) {
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