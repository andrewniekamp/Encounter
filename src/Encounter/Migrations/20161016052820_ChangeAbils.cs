using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Encounter.Migrations
{
    public partial class ChangeAbils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Foes_FoeId",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_CharacterId",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_FoeId",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "FoeId",
                table: "Abilities");

            migrationBuilder.AddColumn<int>(
                name: "Ability1AbilityId",
                table: "Foes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ability2AbilityId",
                table: "Foes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ability3AbilityId",
                table: "Foes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Foes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "Foes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ability1AbilityId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ability2AbilityId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ability3AbilityId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoolDownMiliSecs",
                table: "Abilities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foes_Ability1AbilityId",
                table: "Foes",
                column: "Ability1AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Foes_Ability2AbilityId",
                table: "Foes",
                column: "Ability2AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Foes_Ability3AbilityId",
                table: "Foes",
                column: "Ability3AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Foes_ScenarioId",
                table: "Foes",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Ability1AbilityId",
                table: "Characters",
                column: "Ability1AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Ability2AbilityId",
                table: "Characters",
                column: "Ability2AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Ability3AbilityId",
                table: "Characters",
                column: "Ability3AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Abilities_Ability1AbilityId",
                table: "Characters",
                column: "Ability1AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Abilities_Ability2AbilityId",
                table: "Characters",
                column: "Ability2AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Abilities_Ability3AbilityId",
                table: "Characters",
                column: "Ability3AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foes_Abilities_Ability1AbilityId",
                table: "Foes",
                column: "Ability1AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foes_Abilities_Ability2AbilityId",
                table: "Foes",
                column: "Ability2AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foes_Abilities_Ability3AbilityId",
                table: "Foes",
                column: "Ability3AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foes_Scenarios_ScenarioId",
                table: "Foes",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Abilities_Ability1AbilityId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Abilities_Ability2AbilityId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Abilities_Ability3AbilityId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Foes_Abilities_Ability1AbilityId",
                table: "Foes");

            migrationBuilder.DropForeignKey(
                name: "FK_Foes_Abilities_Ability2AbilityId",
                table: "Foes");

            migrationBuilder.DropForeignKey(
                name: "FK_Foes_Abilities_Ability3AbilityId",
                table: "Foes");

            migrationBuilder.DropForeignKey(
                name: "FK_Foes_Scenarios_ScenarioId",
                table: "Foes");

            migrationBuilder.DropIndex(
                name: "IX_Foes_Ability1AbilityId",
                table: "Foes");

            migrationBuilder.DropIndex(
                name: "IX_Foes_Ability2AbilityId",
                table: "Foes");

            migrationBuilder.DropIndex(
                name: "IX_Foes_Ability3AbilityId",
                table: "Foes");

            migrationBuilder.DropIndex(
                name: "IX_Foes_ScenarioId",
                table: "Foes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Ability1AbilityId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Ability2AbilityId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Ability3AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Ability1AbilityId",
                table: "Foes");

            migrationBuilder.DropColumn(
                name: "Ability2AbilityId",
                table: "Foes");

            migrationBuilder.DropColumn(
                name: "Ability3AbilityId",
                table: "Foes");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Foes");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "Foes");

            migrationBuilder.DropColumn(
                name: "Ability1AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Ability2AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Ability3AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CoolDownMiliSecs",
                table: "Abilities");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Abilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoeId",
                table: "Abilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CharacterId",
                table: "Abilities",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_FoeId",
                table: "Abilities",
                column: "FoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                table: "Abilities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Foes_FoeId",
                table: "Abilities",
                column: "FoeId",
                principalTable: "Foes",
                principalColumn: "FoeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
