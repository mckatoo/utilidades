using System;
using System.Collections.Generic;
using Utilidades.API.Data.Converters;
using Utilidades.API.Data.VO;
using Utilidades.API.Model;
using Utilidades.API.Repository.Generic;

namespace Utilidades.API.Business.Implementattions {
    public class UsersTypeBusinessImpl : IUsersTypeBusiness {
        private IRepository<UsersType> _repository;
        private readonly UsersTypeConverter _converter;
        public UsersTypeBusinessImpl (IRepository<UsersType> repository) {
            _repository = repository;
            _converter = new UsersTypeConverter ();
        }

        public List<UsersTypeVO> FindAll () {
            return _converter.ParseList (_repository.FindAll ());
        }
        public UsersTypeVO FindById (long id) {
            return _converter.Parse (_repository.FindById (id));
        }
        public UsersTypeVO Create (UsersTypeVO type) {
            type.CreatedAt = DateTimeOffset.UtcNow;

            var typeEntity = _converter.Parse (type);
            typeEntity = _repository.Create (typeEntity);

            return _converter.Parse (typeEntity);
        }

        public void Delete (long id) {
            _repository.Delete (id);
        }

        public UsersTypeVO Update (UsersTypeVO type) {
            type.UpdatedAt = DateTimeOffset.UtcNow;

            var typeEntity = _converter.Parse (type);
            typeEntity = _repository.Update (typeEntity);

            return _converter.Parse (typeEntity);
        }
    }
}