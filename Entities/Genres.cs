using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieArchive.Entities
{
    public class Genres    
    {
        [Key]
        public int genreID { get; set; }

        [Required]
        public string genreName { get; set; }

        [ForeignKey("genres_movieGenres")]

        public int MovieGenres movieGenresID { get; set; }

    }

}
