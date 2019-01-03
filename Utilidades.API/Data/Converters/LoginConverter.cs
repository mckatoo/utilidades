using System.Collections.Generic;
using System.Linq;
using Utilidades.API.Data.Converter;
using Utilidades.API.Data.VO;
using Utilidades.API.Model;

namespace Utilidades.API.Data.Converters {
    public class LoginConverter : IParser<LoginVO, Login>, IParser<Login, LoginVO> {
        public Login Parse (LoginVO origin) {
            if (origin == null)
                return new Login ();
            return new Login {
                Id = origin.Id,
                    Name = origin.Name,
                    Email = origin.Email,
                    Password = origin.Password,
                    RememberToken = origin.RememberToken,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
                    UsersTypeId = origin.UsersTypeId
            };
        }

        public LoginVO Parse (Login origin) {
            if (origin == null)
                return new LoginVO ();
            return new LoginVO {
                Id = origin.Id,
                    Name = origin.Name,
                    Email = origin.Email,
                    Password = origin.Password,
                    RememberToken = origin.RememberToken,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
                    UsersTypeId = origin.UsersTypeId
            };
        }

        public List<Login> ParseList (IList<LoginVO> origin) {
            if (origin == null)
                return new List<Login> ();
            return origin.Select (item => Parse (item)).ToList ();
        }

        public List<LoginVO> ParseList (IList<Login> origin) {
            if (origin == null)
                return new List<LoginVO> ();
            return origin.Select (item => Parse (item)).ToList ();
        }
    }
}