using System;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using Utilidades.ApplicationCore.Data.Converters;
using Utilidades.ApplicationCore.Data.VO;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.Infrastructure.Business.Implementattions {
    public class UsersTypeBusinessImpl : IUsersTypeBusiness {
        private IUsersTypeRepository _repository;
        private readonly UsersTypeConverter _converter;
        public UsersTypeBusinessImpl (IUsersTypeRepository repository) {
            _repository = repository;
            _converter = new UsersTypeConverter ();
        }

        public List<UsersTypeVO> FindAll () {
            return _converter.ParseList (_repository.FindAll ());
        }
        public UsersTypeVO FindById (long id) {
            return _converter.Parse (_repository.FindById (id));
        }

        public List<UsersTypeVO> FindByType (string type) {
            return _converter.ParseList (_repository.FindByType (type));
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

        public PagedSearchDTO<UsersTypeVO> FindWithPagedSearch (string type, string sortDirection, int pageSize, int activePage) {
            string query = $"SELECT * FROM utilidades.users_type where 1 = 1 ";
            string countQuery = "SELECT count(*) FROM utilidades.users_type where 1 = 1 ";

            if (!String.IsNullOrWhiteSpace (type) || !String.IsNullOrEmpty (type)) {
                query = query + $"and type like \"%{type}%\" ";
                countQuery = query;
            }

            query = query + $"order by type {sortDirection} limit {pageSize} offset {activePage};";
            var types = _converter.ParseList (_repository.FindWithPagedSearch (query));
            int totalResults = _converter.ParseList (_repository.FindWithPagedSearch (countQuery)).Count;

            return new PagedSearchDTO<UsersTypeVO> {
                CurrentPage = activePage,
                List = types,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
    }
}