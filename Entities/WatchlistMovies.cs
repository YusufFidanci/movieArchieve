using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class WatchlistMovies
    {
        public int watchlistID { get; set; }
        public int movieID { get; set; }

        [ForeignKey("watchlistID")]
        public Watchlists watchlist { get; set; }

        [ForeignKey("movieID")]
        public Movies? movie { get; set; }


    }
}
