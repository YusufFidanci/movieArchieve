using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace movieArchieve.Entities
{
    public class Ratings
    {
        [Key]
        public int ratingID { get; set; }

        [Required]

        public double scor { get; set; }

        public DateTime createdAt { get; set; }


        [ForeignKey("UserID")]
        public int userID { get; set; }
        
        [ForeignKey("MovieID")]
        public int movieID { get; set; }



    }
}
