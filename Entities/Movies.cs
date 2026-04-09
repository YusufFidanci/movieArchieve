using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Movies
    {
        [Key]
        public int movieID { get; set; }

        [Required]
        public string title { get; set; }
        public string? overview { get; set; }
        public DateTime? releaseDate { get; set; }
        public int? runtimeMinutes { get; set; }
        public double? rating { get; set; }

        [ForeignKey("movie_director")]
        public Directors? Director { get; set; }
        
        [ForeignKey("movie_languages")]
        public MovieLangs? Language { get; set; }

        public ICollection<MovieGenres>? MovieGenres { get; set; }
        public ICollection<MovieActors>? MovieActors { get; set; }
        public ICollection<Reviews>? Reviews { get; set; }
        public ICollection<Ratings>? Ratings { get; set; }
        public ICollection<WatchlistMovies>? WatchlistMovies { get; set; }




    }
}
