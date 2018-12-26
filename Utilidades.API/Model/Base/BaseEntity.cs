using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Utilidades.API.Model.Base {
    // Contract between attributes and structures of the table
    // [DataContract]
    public class BaseEntity {
        [Key]
        public long? Id { get; set; }

    }
}