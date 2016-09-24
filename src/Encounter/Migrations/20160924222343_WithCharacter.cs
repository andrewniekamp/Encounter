using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Encounter.Migrations
{
    public partial class WithCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterInstance",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SpriteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.AddColumn<int>(
                name: "CharacterInstanceCharacterId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CharacterInstanceCharacterId",
                table: "Games",
                column: "CharacterInstanceCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Characters_CharacterInstanceCharacterId",
                table: "Games",
                column: "CharacterInstanceCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Characters_CharacterInstanceCharacterId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CharacterInstanceCharacterId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CharacterInstanceCharacterId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "CharacterInstance",
                table: "Games",
                nullable: true);
        }
    }
}
