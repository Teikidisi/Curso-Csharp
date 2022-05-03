using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCMovies.Migrations
{
    public partial class AddedSex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Actors");
        }
    }
}
