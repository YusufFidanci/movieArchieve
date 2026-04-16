using Microsoft.EntityFrameworkCore;
using movieArchieve.Entities;

namespace movieArchieve.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Actors> actors { get; set; }
        public DbSet<Directors> directors { get; set; }
        public DbSet<Movies> movies { get; set; }
        public DbSet<MovieActors> movieActors { get; set; }
        public DbSet<MovieGenres> movieGenres { get; set; }
        public DbSet<MovieLangs> movieLangs { get; set; }
        public DbSet<Genres> genres { get; set; }
        public DbSet<Reviews> reviews { get; set; }
        public DbSet<Ratings> ratings { get; set; }
        public DbSet<WatchlistMovies> watchlistMovies { get; set; }
        public DbSet<Watchlists> watchlists { get; set; }
        public DbSet<Users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenres>()
                .HasKey(mg => new { mg.movieID, mg.genreID });
            modelBuilder.Entity<MovieActors>()
                .HasKey(ml => new { ml.movieID, ml.actorID });
            modelBuilder.Entity<WatchlistMovies>()
                .HasKey(wm => new { wm.watchlistID, wm.movieID });
        }

    }
}
