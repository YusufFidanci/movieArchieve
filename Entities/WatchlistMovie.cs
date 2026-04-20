using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class WatchlistMovie
    {
        public int watchlistID { get; set; }
        public int movieID { get; set; }

        [ForeignKey("watchlistID")]
        public Watchlist? watchlist { get; set; }

        [ForeignKey("movieID")]
        public Movie? movie { get; set; }


    }
}
