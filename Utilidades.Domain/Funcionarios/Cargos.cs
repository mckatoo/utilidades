using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Funcionarios {
    public class Cargos {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public int SetoresId { get; set; }
    }
}