using System;
using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Cargos {
        public Cargos () {
            Funcionarios = new HashSet<Funcionarios> ();
        }

        public int Id { get; set; }
        public string Cargo { get; set; }
        public int SetoresId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual Setores Setores { get; set; }
        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}