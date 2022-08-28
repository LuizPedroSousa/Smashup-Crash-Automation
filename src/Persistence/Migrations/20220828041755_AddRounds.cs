using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Color",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    id = table.Column<string>(type: "uuid", nullable: false),
                    seed = table.Column<string>(type: "TEXT", nullable: false),
                    colorid = table.Column<string>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.id);
                    table.ForeignKey(
                        name: "FK_Round_Color_colorid",
                        column: x => x.colorid,
                        principalTable: "Color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Round_colorid",
                table: "Round",
                column: "colorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Color",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "uuid");
        }
    }
}
