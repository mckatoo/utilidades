using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Cursos : BaseEntity {
        public Cursos () {
            Autorizacoes = new HashSet<Autorizacoes> ();
        }

        public string Curso { get; set; }

        public virtual ICollection<Autorizacoes> Autorizacoes { get; set; }
    }
}