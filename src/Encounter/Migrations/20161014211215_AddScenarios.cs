using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Encounter.Migrations
{
    public partial class AddScenarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventLevel",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    ScenarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.ScenarioId);
                });

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ScenarioId",
                table: "Events",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Scenarios_ScenarioId",
                table: "Events",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Scenarios_ScenarioId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ScenarioId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.AddColumn<int>(
                name: "EventLevel",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }
    }
}
