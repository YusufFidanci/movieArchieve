using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Movie
    {
        [Key]
        public int movieID { get; set; }

        [Required]
        public string title { get; set; }
        public string? overview { get; set; }
        public DateTime? releaseDate { get; set; }
        public int? runtimeMinutes { get; set; }
        public double? rating { get; set; }
        public int? directorID { get; set; }
        public int? languageID { get; set; }
        
        [ForeignKey("directorID")]
        public Director? Director { get; set; }
                
        [ForeignKey("languageID")]
        public MovieLang? Language { get; set; }

        public ICollection<MovieGenre>? MovieGenres { get; set; }
        public ICollection<MovieActor>? MovieActors { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<WatchlistMovie>? WatchlistMovies { get; set; }




    }
}
