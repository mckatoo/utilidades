using System.ComponentModel.DataAnnotations.Schema;
using Utilidades.ApplicationCore.Model.Base;

namespace Utilidades.ApplicationCore.Model {
    [Table ("users_type")]
    public class UsersType : BaseEntity {
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}