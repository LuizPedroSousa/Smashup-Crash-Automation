using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AlterConventionalNamesToPluralAndLowercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Round_roundid",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_User_userid",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Color_colorid",
                table: "Round");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Round",
                table: "Round");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bet",
                table: "Bet");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Round",
                newName: "rounds");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "colors");

            migrationBuilder.RenameTable(
                name: "Bet",
                newName: "bets");

            migrationBuilder.RenameIndex(
                name: "IX_Round_colorid",
                table: "rounds",
                newName: "IX_rounds_colorid");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_userid",
                table: "bets",
                newName: "IX_bets_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_roundid",
                table: "bets",
                newName: "IX_bets_roundid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rounds",
                table: "rounds",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colors",
                table: "colors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bets",
                table: "bets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bets_rounds_roundid",
                table: "bets",
                column: "roundid",
                principalTable: "rounds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bets_users_userid",
                table: "bets",
                column: "userid",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_rounds_colors_colorid",
                table: "rounds",
                column: "colorid",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bets_rounds_roundid",
                table: "bets");

            migrationBuilder.DropForeignKey(
                name: "FK_bets_users_userid",
                table: "bets");

            migrationBuilder.DropForeignKey(
                name: "FK_rounds_colors_colorid",
                table: "rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rounds",
                table: "rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colors",
                table: "colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bets",
                table: "bets");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "rounds",
                newName: "Round");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "Color");

            migrationBuilder.RenameTable(
                name: "bets",
                newName: "Bet");

            migrationBuilder.RenameIndex(
                name: "IX_rounds_colorid",
                table: "Round",
                newName: "IX_Round_colorid");

            migrationBuilder.RenameIndex(
                name: "IX_bets_userid",
                table: "Bet",
                newName: "IX_Bet_userid");

            migrationBuilder.RenameIndex(
                name: "IX_bets_roundid",
                table: "Bet",
                newName: "IX_Bet_roundid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Round",
                table: "Round",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bet",
                table: "Bet",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Round_roundid",
                table: "Bet",
                column: "roundid",
                principalTable: "Round",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_User_userid",
                table: "Bet",
                column: "userid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Color_colorid",
                table: "Round",
                column: "colorid",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
