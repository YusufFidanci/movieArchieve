using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Watchlists
    {
        [Key]
        public int watchlistID { get; set; }

        [Required]
        public string listName { get; set; }

        public DateTime createdAt { get; set; }

        [ForeignKey("UserID")]
        public int userID { get; set; }


    }
}
