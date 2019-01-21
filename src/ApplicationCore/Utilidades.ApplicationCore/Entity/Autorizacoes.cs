using System;
using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Autorizacoes {
        public int Id { get; set; }
        public string Aluno { get; set; }
        public string Ra { get; set; }
        public DateTimeOffset Data { get; set; }
        public DateTimeOffset Validade { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int CursosId { get; set; }
        public string Qrcode { get; set; }

        public virtual Cursos Cursos { get; set; }
    }
}