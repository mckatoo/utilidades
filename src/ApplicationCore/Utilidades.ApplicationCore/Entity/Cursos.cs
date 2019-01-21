using System;
using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Cursos {
        public Cursos () {
            Autorizacoes = new HashSet<Autorizacoes> ();
        }

        public int Id { get; set; }
        public string Curso { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual ICollection<Autorizacoes> Autorizacoes { get; set; }
    }
}