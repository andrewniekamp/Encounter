using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Encounter.Migrations
{
    public partial class AddFoeAbilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoeId",
                table: "Abilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_FoeId",
                table: "Abilities",
                column: "FoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Foes_FoeId",
                table: "Abilities",
                column: "FoeId",
                principalTable: "Foes",
                principalColumn: "FoeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Foes_FoeId",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_FoeId",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "FoeId",
                table: "Abilities");
        }
    }
}
