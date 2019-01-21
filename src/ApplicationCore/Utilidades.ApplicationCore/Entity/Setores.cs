using System;
using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Setores {
        public Setores () {
            Cargos = new HashSet<Cargos> ();
        }

        public int Id { get; set; }
        public string Setor { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual ICollection<Cargos> Cargos { get; set; }
    }
}