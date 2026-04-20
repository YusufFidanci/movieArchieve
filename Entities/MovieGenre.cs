using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class MovieGenre
    {
        public int movieID { get; set; }

        public int genreID { get; set; }

        [ForeignKey("Movie")]
        public Movie? movie { get; set; }

        [ForeignKey("Genre")]
        public Genre? genre { get; set; }
    }
}
