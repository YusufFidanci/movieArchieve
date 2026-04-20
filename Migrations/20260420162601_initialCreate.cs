using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieArchieve.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actor",
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
                    table.PrimaryKey("PK_actor", x => x.actorID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "director",
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
                    table.PrimaryKey("PK_director", x => x.directorID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genre",
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
                    table.PrimaryKey("PK_genre", x => x.genreID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieLang",
                columns: table => new
                {
                    languageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    langName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieLang", x => x.languageID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
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
                    table.PrimaryKey("PK_user", x => x.userID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movie",
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
                    directorID = table.Column<int>(type: "int", nullable: true),
                    languageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.movieID);
                    table.ForeignKey(
                        name: "FK_movie_director_directorID",
                        column: x => x.directorID,
                        principalTable: "director",
                        principalColumn: "directorID");
                    table.ForeignKey(
                        name: "FK_movie_movieLang_languageID",
                        column: x => x.languageID,
                        principalTable: "movieLang",
                        principalColumn: "languageID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "watchlist",
                columns: table => new
                {
                    watchlistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    listName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlist", x => x.watchlistID);
                    table.ForeignKey(
                        name: "FK_watchlist_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieActor",
                columns: table => new
                {
                    movieID = table.Column<int>(type: "int", nullable: false),
                    actorID = table.Column<int>(type: "int", nullable: false),
                    charName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieActor", x => new { x.movieID, x.actorID });
                    table.ForeignKey(
                        name: "FK_movieActor_actor_actorID",
                        column: x => x.actorID,
                        principalTable: "actor",
                        principalColumn: "actorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieActor_movie_movieID",
                        column: x => x.movieID,
                        principalTable: "movie",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieGenre",
                columns: table => new
                {
                    movieID = table.Column<int>(type: "int", nullable: false),
                    genreID = table.Column<int>(type: "int", nullable: false),
                    Movie = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieGenre", x => new { x.movieID, x.genreID });
                    table.ForeignKey(
                        name: "FK_movieGenre_genre_Genre",
                        column: x => x.Genre,
                        principalTable: "genre",
                        principalColumn: "genreID");
                    table.ForeignKey(
                        name: "FK_movieGenre_movie_Movie",
                        column: x => x.Movie,
                        principalTable: "movie",
                        principalColumn: "movieID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    ratingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    score = table.Column<double>(type: "double", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    movieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.ratingID);
                    table.ForeignKey(
                        name: "FK_rating_movie_movieID",
                        column: x => x.movieID,
                        principalTable: "movie",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    movieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_review_movie_movieID",
                        column: x => x.movieID,
                        principalTable: "movie",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_review_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "watchlistMovie",
                columns: table => new
                {
                    watchlistID = table.Column<int>(type: "int", nullable: false),
                    movieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlistMovie", x => new { x.watchlistID, x.movieID });
                    table.ForeignKey(
                        name: "FK_watchlistMovie_movie_movieID",
                        column: x => x.movieID,
                        principalTable: "movie",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_watchlistMovie_watchlist_watchlistID",
                        column: x => x.watchlistID,
                        principalTable: "watchlist",
                        principalColumn: "watchlistID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_movie_directorID",
                table: "movie",
                column: "directorID");

            migrationBuilder.CreateIndex(
                name: "IX_movie_languageID",
                table: "movie",
                column: "languageID");

            migrationBuilder.CreateIndex(
                name: "IX_movieActor_actorID",
                table: "movieActor",
                column: "actorID");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenre_Genre",
                table: "movieGenre",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenre_Movie",
                table: "movieGenre",
                column: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_rating_movieID",
                table: "rating",
                column: "movieID");

            migrationBuilder.CreateIndex(
                name: "IX_rating_userID",
                table: "rating",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_review_movieID",
                table: "review",
                column: "movieID");

            migrationBuilder.CreateIndex(
                name: "IX_review_userID",
                table: "review",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_watchlist_userID",
                table: "watchlist",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_watchlistMovie_movieID",
                table: "watchlistMovie",
                column: "movieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieActor");

            migrationBuilder.DropTable(
                name: "movieGenre");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "watchlistMovie");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.DropTable(
                name: "watchlist");

            migrationBuilder.DropTable(
                name: "director");

            migrationBuilder.DropTable(
                name: "movieLang");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
