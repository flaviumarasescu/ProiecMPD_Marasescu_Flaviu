using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiecMPD_Marasescu_Flaviu.Migrations
{
    public partial class FilmDirector2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilmDirector",
                table: "FilmCategory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmDirectorID",
                table: "FilmCategory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmDirector",
                table: "FilmCategory");

            migrationBuilder.DropColumn(
                name: "FilmDirectorID",
                table: "FilmCategory");
        }
    }
}
