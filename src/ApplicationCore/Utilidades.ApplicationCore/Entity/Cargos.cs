using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Cargos : BaseEntity {
        public Cargos () {
            Funcionarios = new HashSet<Funcionarios> ();
        }

        public string Cargo { get; set; }
        public long SetoresId { get; set; }

        public virtual Setores Setores { get; set; }
        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}