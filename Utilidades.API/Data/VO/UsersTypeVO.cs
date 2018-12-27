using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilidades.API.Data.VO {
    [Table ("users_type")]
    public class UsersTypeVO {
        public long? Id { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }

        [Column ("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column ("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}