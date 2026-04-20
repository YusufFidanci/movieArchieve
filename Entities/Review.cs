using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities;

public class Review
{
    [Key]
    public int reviewID { get; set; }

    [Required]
    public string content { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int userID { get; set; }
    public int movieID { get; set; }
    [ForeignKey("userID")]
    public User? user { get; set; }
      
    [ForeignKey("movieID")]
    public Movie? movie { get; set; }

}
