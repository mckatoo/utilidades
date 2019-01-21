using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Utilidades.ApplicationCore.Model.Base;
using Utilidades.Infrastructure.Data;

namespace Utilidades.Infrastructure.Repository.Generic {
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity {
        protected MySQLContext _context;
        private DbSet<T> dataset;
        public GenericRepository (MySQLContext context) {
            _context = context;
            dataset = _context.Set<T> ();
        }

        public T Create (T item) {
            try {
                dataset.Add (item);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
            return item;
        }

        public void Delete (long id) {
            var result = dataset.SingleOrDefault (u => u.Id.Equals (id));

            try {
                if (result != null)
                    dataset.Remove (result);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool Exists (long? id) {
            if (dataset.Where (u => u.Id.Equals (id)).Take (1).ToList () != null)
                return true;
            return false;
        }

        public List<T> FindAll () {
            return dataset.ToList ();
        }

        public T FindById (long id) {
            if (!Exists (id))
                return null;

            var result = dataset.SingleOrDefault (u => u.Id.Equals (id));

            return result;
        }

        public List<T> FindWithPagedSearch (string query) {
            return dataset.FromSql<T> (query).ToList ();
        }

        public T Update (T item) {
            if (!Exists (item.Id))
                return null;

            var result = dataset.SingleOrDefault (u => u.Id.Equals (item.Id));

            try {
                _context.Entry (result).CurrentValues.SetValues (item);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
            return item;
        }
    }
}