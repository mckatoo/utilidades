using System.Collections.Generic;
using System.Linq;
using Utilidades.ApplicationCore.Data.Converter;
using Utilidades.ApplicationCore.Data.VO;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.ApplicationCore.Data.Converters {
    public class UsersTypeConverter : IParser<UsersTypeVO, UsersType>, IParser<UsersType, UsersTypeVO> {
        public UsersType Parse (UsersTypeVO origin) {
            if (origin == null)
                return new UsersType ();
            return new UsersType {
                Id = origin.Id,
                    Type = origin.Type,
                    Level = origin.Level,
                    Description = origin.Description,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
            };
        }

        public UsersTypeVO Parse (UsersType origin) {
            if (origin == null)
                return new UsersTypeVO ();
            return new UsersTypeVO {
                Id = origin.Id,
                    Type = origin.Type,
                    Level = origin.Level,
                    Description = origin.Description,
                    CreatedAt = origin.CreatedAt,
                    UpdatedAt = origin.UpdatedAt,
            };
        }

        public List<UsersType> ParseList (IList<UsersTypeVO> origin) {
            if (origin == null)
                return new List<UsersType> ();
            return origin.Select (item => Parse (item)).ToList ();
        }

        public List<UsersTypeVO> ParseList (IList<UsersType> origin) {
            if (origin == null)
                return new List<UsersTypeVO> ();
            return origin.Select (item => Parse (item)).ToList ();
        }
    }
}