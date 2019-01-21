using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Utilidades.ApplicationCore.Model.Base {
    // Contract between attributes and structures of the table
    // [DataContract]
    public class BaseEntity {
        [Key]
        public long? Id { get; set; }

        [Column ("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column ("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}