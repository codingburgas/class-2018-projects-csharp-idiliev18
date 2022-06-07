using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace aplusg.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string LastName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
    }
}
