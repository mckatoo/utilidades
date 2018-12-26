using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utilidades.API.Model.Base;

namespace Utilidades.API.Model {
    [Table ("users_type")]
    public class UsersType : BaseEntity {
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }

        [Column ("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column ("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}