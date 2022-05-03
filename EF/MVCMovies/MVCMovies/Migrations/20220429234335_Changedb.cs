using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCMovies.Migrations
{
    public partial class Changedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRate_AspNetUsers_UserId",
                table: "UserRate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRate_Movies_MovieId",
                table: "UserRate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRateActor_Actors_ActorId",
                table: "UserRateActor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRateActor_AspNetUsers_UserId",
                table: "UserRateActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRateActor",
                table: "UserRateActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRate",
                table: "UserRate");

            migrationBuilder.RenameTable(
                name: "UserRateActor",
                newName: "ActorRates");

            migrationBuilder.RenameTable(
                name: "UserRate",
                newName: "MovieRates");

            migrationBuilder.RenameIndex(
                name: "IX_UserRateActor_UserId",
                table: "ActorRates",
                newName: "IX_ActorRates_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRateActor_ActorId",
                table: "ActorRates",
                newName: "IX_ActorRates_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRate_UserId",
                table: "MovieRates",
                newName: "IX_MovieRates_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRate_MovieId",
                table: "MovieRates",
                newName: "IX_MovieRates_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorRates",
                table: "ActorRates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieRates",
                table: "MovieRates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorRates_Actors_ActorId",
                table: "ActorRates",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorRates_AspNetUsers_UserId",
                table: "ActorRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorRates_Actors_ActorId",
                table: "ActorRates");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorRates_AspNetUsers_UserId",
                table: "ActorRates");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRates_AspNetUsers_UserId",
                table: "MovieRates");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRates_Movies_MovieId",
                table: "MovieRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieRates",
                table: "MovieRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorRates",
                table: "ActorRates");

            migrationBuilder.RenameTable(
                name: "MovieRates",
                newName: "UserRate");

            migrationBuilder.RenameTable(
                name: "ActorRates",
                newName: "UserRateActor");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRates_UserId",
                table: "UserRate",
                newName: "IX_UserRate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRates_MovieId",
                table: "UserRate",
                newName: "IX_UserRate_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorRates_UserId",
                table: "UserRateActor",
                newName: "IX_UserRateActor_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorRates_ActorId",
                table: "UserRateActor",
                newName: "IX_UserRateActor_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRate",
                table: "UserRate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRateActor",
                table: "UserRateActor",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRateActor_Actors_ActorId",
                table: "UserRateActor",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRateActor_AspNetUsers_UserId",
                table: "UserRateActor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
