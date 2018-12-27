using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilidades.API.Data.VO {
    [Table ("users")]
    public class UserVO {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Column ("remember_token")]
        public string RememberToken { get; set; }

        [Column ("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column ("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Column ("users_type_id")]
        public long? UsersTypeId { get; set; }
    }
}