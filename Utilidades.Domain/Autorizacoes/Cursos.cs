using System;
using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Autorizacoes {
    public class Cursos {
        public int Id { get; set; }

        [Required]
        public string Curso { get; set; }
        public DateTimeOffset Created_at { get; set; }
        public DateTimeOffset Updated_at { get; set; }

        public Cursos (string curso) {
            setProperties (curso);
            Created_at = DateTimeOffset.UtcNow;
        }

        public void Update (string curso) {
            setProperties (curso);
            Updated_at = DateTimeOffset.UtcNow;
        }
        private void setProperties (string curso) {
            Curso = curso;
        }
    }
}