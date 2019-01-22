using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Users : BaseEntity {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public long UsersTypeId { get; set; }

        public virtual UsersType UsersType { get; set; }
    }
}