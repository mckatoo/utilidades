using System;
using System.Collections.Generic;
using System.Threading;
using Utilidades.API.Model;

namespace Utilidades.API.Services.Implementations {
    public class UserServiceImplementation : IUserService {
        private volatile int count;

        List<User> IUserService.FindAll () {
            List<User> users = new List<User> ();
            for (int i = 0; i < 8; i++) {
                User user = MockUser (i);
                users.Add (user);
            }
            return users;
        }

        private User MockUser (int i) {
            return new User {
                Id = IncrementAndGet (),
                    Name = "User Name " + i,
                    Email = $"email{i}@email.com",
                    Password = $"{i}_pass_{i}_pass_{i}",
                    RememberToken = $"{i}_token_{i}",
                    CreatedAt = new DateTimeOffset (),
                    UpdatedAt = new DateTimeOffset ().AddDays (1)
            };
        }

        private long IncrementAndGet () {
            return Interlocked.Increment (ref count);
        }

        public User FindById (long id) {
            return new User {
                Id = IncrementAndGet (),
                    Name = "Milton",
                    Email = "mckatoo@gmail.com",
                    Password = "*******",
                    RememberToken = "alsfjlasfjdsjf",
                    CreatedAt = new DateTimeOffset (),
                    UpdatedAt = new DateTimeOffset ().AddDays (1)
            };
        }
        public User Create (User user) {
            return user;
        }

        public void Delete (User user) { }

        public User FindAll () {
            throw new System.NotImplementedException ();
        }

        public User Update (User user) {
            return user;
        }
    }
}