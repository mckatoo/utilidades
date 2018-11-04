using System;
using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Autorizacoes {
    public class Autorizacoes {

        public Autorizacoes (string aluno, string ra, DateTimeOffset data, DateTimeOffset validade, DateTimeOffset created_at, DateTimeOffset updated_at, Cursos cursos, string qrcode) {
            setProperties (aluno, ra, data, validade, created_at, updated_at, cursos);
            Qrcode = qrcode;
        }
        public void Update (string aluno, string ra, DateTimeOffset data, DateTimeOffset validade, DateTimeOffset created_at, DateTimeOffset updated_at, Cursos cursos, string qrcode) {
            setProperties (aluno, ra, data, validade, created_at, updated_at, cursos);
            Qrcode = qrcode;
        }

        private void setProperties (string aluno, string ra, DateTimeOffset data, DateTimeOffset validade, DateTimeOffset created_at, DateTimeOffset updated_at, Cursos cursos) {
            Aluno = aluno;
            Ra = ra;
            Data = data;
            Validade = validade;
            Created_at = created_at;
            Updated_at = updated_at;
            Cursos = cursos;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Aluno { get; set; }

        [Required]
        public string Ra { get; set; }

        [Required]
        public DateTimeOffset Data { get; set; }

        [Required]
        public DateTimeOffset Validade { get; set; }
        public DateTimeOffset Created_at { get; set; }
        public DateTimeOffset Updated_at { get; set; }

        [Required]
        public Cursos Cursos { get; set; }

        [Required]
        public string Qrcode { get; set; }

    }
}