using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Watchlist
    {
        [Key]
        public int watchlistID { get; set; }

        [Required]
        public string listName { get; set; }
 
        public DateTime createdAt { get; set; }

        public int userID { get; set; }
        [ForeignKey("userID")]
        public User? User { get; set; }

    }
}
