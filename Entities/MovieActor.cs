using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class MovieActor
    {
        public int movieID { get; set; }

        public int actorID { get; set; }
        public string? charName { get; set; }

        [ForeignKey("movieID")]
        public Movie? movie { get; set; }
        [ForeignKey("actorID")]
        public Actor? actor { get; set; }
         
    }
}
