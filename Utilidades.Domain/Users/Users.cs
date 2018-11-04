using System;
using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Users {
    public class Users {
        public Users (string name, string email, string password, string rememberToken, UsersType usersType) {
            setProperties (name, email, password, rememberToken, usersType);
        }
        public void Update (string name, string email, string password, string rememberToken, UsersType usersType) {
            setProperties (name, email, password, rememberToken, usersType);
        }
        private void setProperties (string name, string email, string password, string rememberToken, UsersType usersType) {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.RememberToken = rememberToken;
            this.Created_at = DateTimeOffset.UtcNow;
            this.Updated_at = DateTimeOffset.UtcNow;
            this.UsersType = usersType;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTimeOffset Created_at { get; set; }
        public DateTimeOffset Updated_at { get; set; }

        [Required]
        public UsersType UsersType { get; set; }
    }
}