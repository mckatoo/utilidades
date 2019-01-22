using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Setores : BaseEntity {
        public Setores () {
            Cargos = new HashSet<Cargos> ();
        }

        public string Setor { get; set; }

        public virtual ICollection<Cargos> Cargos { get; set; }
    }
}