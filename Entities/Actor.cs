using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Actor
    {
        [Key]
        public int actorID { get; set; }
        [Required]
        public string fullName { get; set; }
        
        public int age { get; set; }
    }
}
