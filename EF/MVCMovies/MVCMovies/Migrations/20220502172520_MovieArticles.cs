using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCMovies.Migrations
{
    public partial class MovieArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorRates_Actors_ActorId",
                table: "ActorRates");

            migrationBuilder.AddColumn<string>(
                name: "PosterUri",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Stars",
                table: "ActorRates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorRates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MovieArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieArticles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorRates_Actors_ActorId",
                table: "ActorRates",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorRates_Actors_ActorId",
                table: "ActorRates");

            migrationBuilder.DropTable(
                name: "MovieArticles");

            migrationBuilder.DropColumn(
                name: "PosterUri",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "Stars",
                table: "ActorRates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorRates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorRates_Actors_ActorId",
                table: "ActorRates",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
