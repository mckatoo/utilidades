using System.Collections.Generic;
using Utilidades.ApplicationCore.Model.Base;

namespace Utilidades.Infrastructure.Repository.Generic {
    public interface IRepository<T> where T : BaseEntity {
        T FindById (long id);
        List<T> FindAll ();
        List<T> FindWithPagedSearch (string query);
        T Create (T item);
        T Update (T item);
        void Delete (long id);
        bool Exists (long? id);
    }
}