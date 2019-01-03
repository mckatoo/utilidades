using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tapioca.HATEOAS;

namespace Utilidades.API.Model {
    [Table ("users")]
    public class LoginVO : ISupportsHyperMedia {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Column ("remember_token")]
        public string RememberToken { get; set; }

        [Column ("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column ("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Column ("users_type_id")]
        public long? UsersTypeId { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink> ();
    }
}