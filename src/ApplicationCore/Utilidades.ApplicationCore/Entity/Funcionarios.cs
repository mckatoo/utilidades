using System;
using System.Collections.Generic;
using Utilidades.ApplicationCore.Entity.Base;

namespace Utilidades.ApplicationCore.Entity {
    public partial class Funcionarios : BaseEntity {
        public string Nome { get; set; }
        public string Funcional { get; set; }
        public string Rg { get; set; }
        public long CargosId { get; set; }
        public string FilePhoto { get; set; }

        public virtual Cargos Cargos { get; set; }
    }
}