using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class WatchlistMovies
    {
        public int watchlistID { get; set; }
        public int movieID { get; set; }

        [ForeignKey("watchlist")]
        public Watchlists watchlist { get; set; }

        [ForeignKey("movie")]
        public Movies? movie { get; set; }


    }
}
