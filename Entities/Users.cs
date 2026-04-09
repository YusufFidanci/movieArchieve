using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Users
    {
        [Key]
        public int userID { get; set; }

        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string passwordHash { get; set; }
        public DateTime createdAt { get; set; }
    }
}
