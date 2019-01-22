using System.Collections.Generic;
using System.Linq;
using Utilidades.ApplicationCore.Data.Converter;
using Utilidades.ApplicationCore.Data.VO;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.ApplicationCore.Data.Converters {
    public class UserConverter : IParser<UserVO, Users>, IParser<Users, UserVO> {
        public Users Parse (UserVO origin) {
            if (origin == null)
                return new Users ();
            return new Users {
                Id = origin.Id,
                    Name = origin.Name,
                    Email = origin.Email,
                    Username = origin.Username,
                    Password = origin.Password,
                    RememberToken = origin.RememberToken,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
                    UsersType = origin.UsersType
            };
        }

        public UserVO Parse (Users origin) {
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
                    UsersType = origin.UsersType
            };
        }

        public List<Users> ParseList (IList<UserVO> origin) {
            if (origin == null)
                return new List<Users> ();
            return origin.Select (item => Parse (item)).ToList ();
        }

        public List<UserVO> ParseList (IList<Users> origin) {
            if (origin == null)
                return new List<UserVO> ();
            return origin.Select (item => Parse (item)).ToList ();
        }
    }
}