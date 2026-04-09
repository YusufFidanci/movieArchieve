using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Reviews
    {
        [Key]
        public int reviewID { get; set; }

        [Required]
        public string content { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
       
        [ForeignKey("review_user")]
        public int userID { get; set; }
        
        [ForeignKey("review_movie")]
        public int movieID { get; set; }


    }
}
