using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class Genres    
    {
        [Key]
        public int genreID { get; set; }
        public int movieGenresID { get; set; }

        [Required]
        public string genreName { get; set; }

        [ForeignKey("genres_movieGenres")]

        public MovieGenres? movieGenres { get; set; }

    }

}
