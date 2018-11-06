using System;

namespace Utilidades.Domain.Dtos {
    public class TypeDto {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created_at { get; set; }
        public DateTimeOffset Updated_at { get; set; }
    }
}