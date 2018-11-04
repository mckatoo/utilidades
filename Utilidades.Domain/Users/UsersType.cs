using System;
using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Users {
    public class UsersType {
        public UsersType (string type, int level, string description, DateTimeOffset created_at, DateTimeOffset updated_at) {
            this.Type = type;
            setProperties (level, description, created_at, updated_at);
        }
        public void Update (string type, int level, string description, DateTimeOffset created_at, DateTimeOffset updated_at) {
            this.Type = type;
            setProperties (level, description, created_at, updated_at);
        }

        private void setProperties (int level, string description, DateTimeOffset created_at, DateTimeOffset updated_at) {
            this.Level = level;
            this.Description = description;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTimeOffset Created_at { get; set; }
        public DateTimeOffset Updated_at { get; set; }
    }
}