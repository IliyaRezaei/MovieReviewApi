using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviewApi.Migrations
{
    /// <inheritdoc />
    public partial class movieReviewDataContextFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_MovieCrew_ActorId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirector_MovieCrew_DirectorId",
                table: "MovieDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirector_Movies_MovieId",
                table: "MovieDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genres_GenreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movies_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirector",
                table: "MovieDirector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor");

            migrationBuilder.RenameTable(
                name: "MovieGenre",
                newName: "MovieGenres");

            migrationBuilder.RenameTable(
                name: "MovieDirector",
                newName: "MovieDirectors");

            migrationBuilder.RenameTable(
                name: "MovieActor",
                newName: "MovieActors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirector_DirectorId",
                table: "MovieDirectors",
                newName: "IX_MovieDirectors_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActors",
                newName: "IX_MovieActors_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors",
                columns: new[] { "MovieId", "DirectorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors",
                columns: new[] { "MovieId", "ActorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_MovieCrew_ActorId",
                table: "MovieActors",
                column: "ActorId",
                principalTable: "MovieCrew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_MovieCrew_DirectorId",
                table: "MovieDirectors",
                column: "DirectorId",
                principalTable: "MovieCrew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Genres_GenreId",
                table: "MovieGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Movies_MovieId",
                table: "MovieGenres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_MovieCrew_ActorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_MovieCrew_DirectorId",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenreId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MovieId",
                table: "MovieGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors");

            migrationBuilder.RenameTable(
                name: "MovieGenres",
                newName: "MovieGenre");

            migrationBuilder.RenameTable(
                name: "MovieDirectors",
                newName: "MovieDirector");

            migrationBuilder.RenameTable(
                name: "MovieActors",
                newName: "MovieActor");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenre",
                newName: "IX_MovieGenre_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirectors_DirectorId",
                table: "MovieDirector",
                newName: "IX_MovieDirector_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActor",
                newName: "IX_MovieActor_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirector",
                table: "MovieDirector",
                columns: new[] { "MovieId", "DirectorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor",
                columns: new[] { "MovieId", "ActorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_MovieCrew_ActorId",
                table: "MovieActor",
                column: "ActorId",
                principalTable: "MovieCrew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirector_MovieCrew_DirectorId",
                table: "MovieDirector",
                column: "DirectorId",
                principalTable: "MovieCrew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirector_Movies_MovieId",
                table: "MovieDirector",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genres_GenreId",
                table: "MovieGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movies_MovieId",
                table: "MovieGenre",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
