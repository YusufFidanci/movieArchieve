using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace movieArchieve.Entities;

public class Ratings
{
    [Key]
    public int ratingID { get; set; }

    [Required]

    public double scor { get; set; }
    [Required]  
    public DateTime createdAt { get; set; }


    [ForeignKey("UserID")]
    public Users? user { get; set; }
    
    [ForeignKey("MovieID")]
    public Movies movie { get; set; }



}
