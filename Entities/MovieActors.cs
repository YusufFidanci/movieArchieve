using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class MovieActors
    {
        public int movieID { get; set; }

        public int actorID { get; set; }
        public string? charName { get; set; }

        [ForeignKey("movies")]
        public Movies movie { get; set; }
        [ForeignKey("actors")]
        public Actors actor { get; set; }

    }
}
