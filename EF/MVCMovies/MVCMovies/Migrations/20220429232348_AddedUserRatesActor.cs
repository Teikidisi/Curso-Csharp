using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCMovies.Migrations
{
    public partial class AddedUserRatesActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRates_AspNetUsers_UserId",
                table: "MovieRates");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRates_Movies_MovieId",
                table: "MovieRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieRates",
                table: "MovieRates");

            migrationBuilder.RenameTable(
                name: "MovieRates",
                newName: "UserRate");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRates_UserId",
                table: "UserRate",
                newName: "IX_UserRate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRates_MovieId",
                table: "UserRate",
                newName: "IX_UserRate_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRate",
                table: "UserRate",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRateActor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRateActor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRateActor_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRateActor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRateActor_ActorId",
                table: "UserRateActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRateActor_UserId",
                table: "UserRateActor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRate_AspNetUsers_UserId",
                table: "UserRate",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRate_Movies_MovieId",
                table: "UserRate",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRate_AspNetUsers_UserId",
                table: "UserRate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRate_Movies_MovieId",
                table: "UserRate");

            migrationBuilder.DropTable(
                name: "UserRateActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRate",
                table: "UserRate");

            migrationBuilder.RenameTable(
                name: "UserRate",
                newName: "MovieRates");

            migrationBuilder.RenameIndex(
                name: "IX_UserRate_UserId",
                table: "MovieRates",
                newName: "IX_MovieRates_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRate_MovieId",
                table: "MovieRates",
                newName: "IX_MovieRates_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieRates",
                table: "MovieRates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRates_AspNetUsers_UserId",
                table: "MovieRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRates_Movies_MovieId",
                table: "MovieRates",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
