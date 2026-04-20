using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace movieArchieve.Entities;

public class Rating
{
    [Key]
    public int ratingID { get; set; }

    [Required]
    public double score { get; set; }
    [Required]  
    public DateTime createdAt { get; set; }
    public int userID { get; set; }
    public int movieID { get; set; }
    
    [ForeignKey("userID")]
    public User? user { get; set; }
    
    [ForeignKey("movieID")]
    public Movie? movie { get; set; }

}
