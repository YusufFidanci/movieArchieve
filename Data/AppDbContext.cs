using Microsoft.EntityFrameworkCore;
using movieArchieve.Entities;

namespace movieArchieve.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Actor> actor { get; set; }
    public DbSet<Director> director { get; set; }
    public DbSet<Movie> movie { get; set; }
    public DbSet<MovieActor> movieActor { get; set; }
    public DbSet<MovieGenre> movieGenre { get; set; }
    public DbSet<MovieLang> movieLang { get; set; }
    public DbSet<Genre> genre { get; set; }
    public DbSet<Review> review { get; set; }
    public DbSet<Rating> rating { get; set; }
    public DbSet<WatchlistMovie> watchlistMovie { get; set; }
    public DbSet<Watchlist> watchlist { get; set; }
    public DbSet<User> user { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.movieID, mg.genreID });
        modelBuilder.Entity<MovieActor>()
            .HasKey(ml => new { ml.movieID, ml.actorID });
        modelBuilder.Entity<WatchlistMovie>()
            .HasKey(wm => new { wm.watchlistID, wm.movieID });
    }
}
