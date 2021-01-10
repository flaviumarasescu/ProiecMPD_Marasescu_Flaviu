using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiecMPD_Marasescu_Flaviu.Migrations
{
    public partial class FilmD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmDirector",
                table: "FilmCategory");

            migrationBuilder.DropColumn(
                name: "FilmDirectorID",
                table: "FilmCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilmDirector",
                table: "FilmCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmDirectorID",
                table: "FilmCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
