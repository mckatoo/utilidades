using System;
using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Funcionarios {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcional { get; set; }
        public string Rg { get; set; }
        public int CargosId { get; set; }
        public string FilePhoto { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual Cargos Cargos { get; set; }
    }
}