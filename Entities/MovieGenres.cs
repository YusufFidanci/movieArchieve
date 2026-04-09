using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class MovieGenres
    {
        public int movieID { get; set; }

        public int genreID { get; set; }

        [ForeignKey("Movie")]
        public Movies? movie { get; set; }

        [ForeignKey("Genre")]
        public Genres? genre { get; set; }
    }
}
