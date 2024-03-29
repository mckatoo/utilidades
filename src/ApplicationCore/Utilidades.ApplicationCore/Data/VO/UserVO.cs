using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tapioca.HATEOAS;
using Utilidades.ApplicationCore.Entity;

namespace Utilidades.ApplicationCore.Data.VO {
    [Table ("users")]
    public class UserVO : ISupportsHyperMedia {
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
        public UsersType UsersType { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink> ();
    }
}