using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Funcionarios {
    public class Funcionarios {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Funcional { get; set; }

        [Required]
        public string Rg { get; set; }

        [Required]
        public int CargosId { get; set; }
    }
}