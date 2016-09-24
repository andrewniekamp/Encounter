using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Encounter.Migrations
{
    public partial class GameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterInstance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.AddColumn<int>(
                name: "GameInstanceGameId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameInstanceGameId",
                table: "Players",
                column: "GameInstanceGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameInstanceGameId",
                table: "Players",
                column: "GameInstanceGameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameInstanceGameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GameInstanceGameId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameInstanceGameId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
