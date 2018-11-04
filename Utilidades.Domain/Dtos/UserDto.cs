using System;

namespace Utilidades.Domain.Dtos {
    public class UserDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTimeOffset Created_at { get; set; }
        public DateTimeOffset Updated_at { get; set; }
        public int UsersTypeId { get; set; }
    }
}