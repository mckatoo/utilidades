using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Funcionarios {
    public class Setores {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Setor { get; set; }
    }
}