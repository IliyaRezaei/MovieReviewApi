using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviewApi.Migrations
{
    /// <inheritdoc />
    public partial class MergingFirstnameAndLastnameOfPersonIntoFullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "MovieCrew");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "MovieCrew",
                newName: "Fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "MovieCrew",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "MovieCrew",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
