using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieArchieve.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    actorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.actorID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    directorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    age = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directors", x => x.directorID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    genreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    movieGenresID = table.Column<int>(type: "int", nullable: false),
                    genreName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.genreID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieLangs",
                columns: table => new
                {
                    languageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    langName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieLangs", x => x.languageID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passwordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    overview = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    releaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    runtimeMinutes = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<double>(type: "double", nullable: true),
                    movie_director = table.Column<int>(type: "int", nullable: true),
                    movie_languages = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.movieID);
                    table.ForeignKey(
                        name: "FK_movies_directors_movie_director",
                        column: x => x.movie_director,
                        principalTable: "directors",
                        principalColumn: "directorID");
                    table.ForeignKey(
                        name: "FK_movies_movieLangs_movie_languages",
                        column: x => x.movie_languages,
                        principalTable: "movieLangs",
                        principalColumn: "languageID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    watchlistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    listName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlists", x => x.watchlistID);
                    table.ForeignKey(
                        name: "FK_watchlists_users_User",
                        column: x => x.User,
                        principalTable: "users",
                        principalColumn: "userID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieActors",
                columns: table => new
                {
                    movieID = table.Column<int>(type: "int", nullable: false),
                    actorID = table.Column<int>(type: "int", nullable: false),
                    charName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    movies = table.Column<int>(type: "int", nullable: true),
                    actors = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieActors", x => new { x.movieID, x.actorID });
                    table.ForeignKey(
                        name: "FK_movieActors_actors_actors",
                        column: x => x.actors,
                        principalTable: "actors",
                        principalColumn: "actorID");
                    table.ForeignKey(
                        name: "FK_movieActors_movies_movies",
                        column: x => x.movies,
                        principalTable: "movies",
                        principalColumn: "movieID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieGenres",
                columns: table => new
                {
                    movieID = table.Column<int>(type: "int", nullable: false),
                    genreID = table.Column<int>(type: "int", nullable: false),
                    Movie = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieGenres", x => new { x.movieID, x.genreID });
                    table.ForeignKey(
                        name: "FK_movieGenres_genres_Genre",
                        column: x => x.Genre,
                        principalTable: "genres",
                        principalColumn: "genreID");
                    table.ForeignKey(
                        name: "FK_movieGenres_movies_Movie",
                        column: x => x.Movie,
                        principalTable: "movies",
                        principalColumn: "movieID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    ratingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    scor = table.Column<double>(type: "double", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    MovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.ratingID);
                    table.ForeignKey(
                        name: "FK_ratings_movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "movies",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ratings_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    review_user = table.Column<int>(type: "int", nullable: true),
                    review_movie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_reviews_movies_review_movie",
                        column: x => x.review_movie,
                        principalTable: "movies",
                        principalColumn: "movieID");
                    table.ForeignKey(
                        name: "FK_reviews_users_review_user",
                        column: x => x.review_user,
                        principalTable: "users",
                        principalColumn: "userID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "watchlistMovies",
                columns: table => new
                {
                    watchlistID = table.Column<int>(type: "int", nullable: false),
                    movieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlistMovies", x => new { x.watchlistID, x.movieID });
                    table.ForeignKey(
                        name: "FK_watchlistMovies_movies_movieID",
                        column: x => x.movieID,
                        principalTable: "movies",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_watchlistMovies_watchlists_watchlistID",
                        column: x => x.watchlistID,
                        principalTable: "watchlists",
                        principalColumn: "watchlistID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_movieActors_actors",
                table: "movieActors",
                column: "actors");

            migrationBuilder.CreateIndex(
                name: "IX_movieActors_movies",
                table: "movieActors",
                column: "movies");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenres_Genre",
                table: "movieGenres",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenres_Movie",
                table: "movieGenres",
                column: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_movies_movie_director",
                table: "movies",
                column: "movie_director");

            migrationBuilder.CreateIndex(
                name: "IX_movies_movie_languages",
                table: "movies",
                column: "movie_languages");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_MovieID",
                table: "ratings",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_UserID",
                table: "ratings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_review_movie",
                table: "reviews",
                column: "review_movie");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_review_user",
                table: "reviews",
                column: "review_user");

            migrationBuilder.CreateIndex(
                name: "IX_watchlistMovies_movieID",
                table: "watchlistMovies",
                column: "movieID");

            migrationBuilder.CreateIndex(
                name: "IX_watchlists_User",
                table: "watchlists",
                column: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieActors");

            migrationBuilder.DropTable(
                name: "movieGenres");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "watchlistMovies");

            migrationBuilder.DropTable(
                name: "actors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "watchlists");

            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropTable(
                name: "movieLangs");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
