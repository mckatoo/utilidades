using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Autorizacoes : BaseEntity {
        public string Aluno { get; set; }
        public string Ra { get; set; }
        public DateTimeOffset Data { get; set; }
        public DateTimeOffset Validade { get; set; }
        public long CursosId { get; set; }
        public string Qrcode { get; set; }

        public virtual Cursos Cursos { get; set; }
    }
}