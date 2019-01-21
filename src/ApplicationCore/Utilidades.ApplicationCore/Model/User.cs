using System.ComponentModel.DataAnnotations.Schema;
using Utilidades.ApplicationCore.Model.Base;

namespace Utilidades.ApplicationCore.Model {
    [Table ("users")]
    public class User : BaseEntity {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Column ("remember_token")]
        public string RememberToken { get; set; }

        [Column ("users_type_id")]
        public long? UsersTypeId { get; set; }
    }
}