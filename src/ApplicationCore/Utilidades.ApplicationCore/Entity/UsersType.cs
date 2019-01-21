using System;
using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Entity {
    public partial class UsersType {
        public UsersType () {
            Users = new HashSet<Users> ();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}