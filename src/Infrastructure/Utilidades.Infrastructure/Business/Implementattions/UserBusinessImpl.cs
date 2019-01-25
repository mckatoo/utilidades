using System;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using Utilidades.ApplicationCore.Data.Converters;
using Utilidades.ApplicationCore.Data.VO;
using Utilidades.ApplicationCore.Entity;
using Utilidades.Infrastructure.Repository;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Business.Implementattions {
    public class UserBusinessImpl : IUserBusiness {
        private IUserRepository _repository;
        private readonly UserConverter _converter;
        public UserBusinessImpl (IUserRepository repository) {
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

        public List<UserVO> FindByName (string name) {
            return _converter.ParseList (_repository.FindByName (name));
        }

        public PagedSearchDTO<UserVO> FindWithPagedSearch (string name, string sortDirection, int pageSize, int activePage) {
            activePage = activePage > 0 ? activePage - 1 : 0;
            string table = "utilidades.users";
            string field = "name";
            string query = $"SELECT * FROM {table} where 1 = 1 ";
            string countQuery = $"SELECT count(*) FROM {table} where 1 = 1 ";

            if (!String.IsNullOrWhiteSpace (name) || !String.IsNullOrEmpty (name)) {
                query = query + $"and {field} like \"%{name}%\" ";
                countQuery = query;
            }

            query = query + $"order by {field} {sortDirection} limit {pageSize} offset {activePage};";
            var names = _converter.ParseList (_repository.FindWithPagedSearch (query));
            int totalResults = _converter.ParseList (_repository.FindWithPagedSearch (countQuery)).Count;

            return new PagedSearchDTO<UserVO> {
                CurrentPage = activePage + 1,
                List = names,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
    }
}