using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddBets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "User",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    id = table.Column<string>(type: "uuid", nullable: false),
                    amount = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    roundid = table.Column<string>(type: "uuid", nullable: true),
                    userid = table.Column<string>(type: "uuid", nullable: true),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bet_Round_roundid",
                        column: x => x.roundid,
                        principalTable: "Round",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Bet_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_roundid",
                table: "Bet",
                column: "roundid");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_userid",
                table: "Bet",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "User",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "uuid");
        }
    }
}
