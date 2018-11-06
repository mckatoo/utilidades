using System;
using System.ComponentModel.DataAnnotations;

namespace Utilidades.Domain.Users {
    public class UsersType {
        public UsersType (string type, int level, string description) {
            this.Type = type;
            setProperties (level, description);
            this.Created_at = DateTimeOffset.UtcNow;
        }
        public void Update (string type, int level, string description) {
            this.Type = type;
            setProperties (level, description);
            this.Updated_at = DateTimeOffset.UtcNow;
        }

        private void setProperties (int level, string description) {
            this.Level = level;
            this.Description = description;
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