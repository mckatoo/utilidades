using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;

namespace Utilidades.API.Business.Implementattions {
    public class UserRepositoryImplementattion : IUserRepository {
        private MySQLContext _context;
        public UserRepositoryImplementattion (MySQLContext context) {
            _context = context;
        }

        public List<User> FindAll () {
            return _context.Users.ToList ();
        }
        public User FindById (long id) {
            if (!Exists (id))
                return null;

            var result = _context.Users.SingleOrDefault (u => u.Id.Equals (id));

            return result;
        }
        public User Create (User user) {
            try {
                _context.Add (user);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
            return user;
        }

        public void Delete (long id) {
            var result = _context.Users.SingleOrDefault (u => u.Id.Equals (id));

            try {
                if (result != null)
                    _context.Users.Remove (result);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public User Update (User user) {
            if (!Exists (user.Id))
                return null;

            var result = _context.Users.SingleOrDefault (u => u.Id.Equals (user.Id));

            try {
                _context.Entry (result).CurrentValues.SetValues (user);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
            return user;
        }

        public bool Exists (long? id) {
            // _context.Users.Any (u => u.Id.Equals (id));
            if (_context.Users.Where (u => u.Id.Equals (id)).Take(1).ToList() != null)
                return true;
            return false;
        }
    }
}