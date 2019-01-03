using System.Collections.Generic;
using System.Linq;
using Utilidades.API.Data.Converter;
using Utilidades.API.Data.VO;
using Utilidades.API.Model;

namespace Utilidades.API.Data.Converters {
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO> {
        public User Parse (UserVO origin) {
            if (origin == null)
                return new User ();
            return new User {
                Id = origin.Id,
                    Name = origin.Name,
                    Email = origin.Email,
                    Username = origin.Username,
                    Password = origin.Password,
                    RememberToken = origin.RememberToken,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
                    UsersTypeId = origin.UsersTypeId
            };
        }

        public UserVO Parse (User origin) {
            if (origin == null)
                return new UserVO ();
            return new UserVO {
                Id = origin.Id,
                    Name = origin.Name,
                    Email = origin.Email,
                    Username = origin.Username,
                    Password = origin.Password,
                    RememberToken = origin.RememberToken,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
                    UsersTypeId = origin.UsersTypeId
            };
        }

        public List<User> ParseList (IList<UserVO> origin) {
            if (origin == null)
                return new List<User> ();
            return origin.Select (item => Parse (item)).ToList ();
        }

        public List<UserVO> ParseList (IList<User> origin) {
            if (origin == null)
                return new List<UserVO> ();
            return origin.Select (item => Parse (item)).ToList ();
        }
    }
}