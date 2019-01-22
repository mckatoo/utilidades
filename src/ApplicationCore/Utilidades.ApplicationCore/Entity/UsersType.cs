using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class UsersType : BaseEntity {
        public UsersType () {
            Users = new HashSet<Users> ();
        }

        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}