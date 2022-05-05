using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAppNet5.Server.Migrations
{
    public partial class AddedFieldsActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Actors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Actors");
        }
    }
}
