using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utilidades.API.Model;
using Utilidades.API.Model.Context;

namespace Utilidades.API.Business.Implementations {
    public class UserBusinessImplementation : IUserBusiness {
        private IUserRepository _repository;
        public UserBusinessImplementation (IUserRepository repository) {
            _repository = repository;
        }

        public List<User> FindAll () {
            return _context.Users.ToList ();
        }
        public User FindById (long id) {
            if (!Exist (id))
                return new User ();

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

        public void Delete (User user) {
            var result = _context.Users.SingleOrDefault (u => u.Equals (user));

            try {
                if (result != null)
                    _context.Users.Remove (result);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public User Update (User user) {
            if (!Exist (user.Id))
                return new User ();

            var result = _context.Users.SingleOrDefault (u => u.Id.Equals (user.Id));

            try {
                _context.Entry (result).CurrentValues.SetValues (user);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
            return user;
        }

        private bool Exist (long? id) {
            return _context.Users.Any (u => u.Id.Equals (id));
        }
    }
}