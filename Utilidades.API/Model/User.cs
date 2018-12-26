using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utilidades.API.Model.Base;

namespace Utilidades.API.Model {
    [Table ("users")]
    public class User : BaseEntity {
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