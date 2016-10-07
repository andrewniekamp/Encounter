using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Encounter.Migrations
{
    public partial class FoeToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foes_Events_EventId",
                table: "Foes");

            migrationBuilder.DropIndex(
                name: "IX_Foes_EventId",
                table: "Foes");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Foes");

            migrationBuilder.AddColumn<int>(
                name: "FoeId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_FoeId",
                table: "Events",
                column: "FoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Foes_FoeId",
                table: "Events",
                column: "FoeId",
                principalTable: "Foes",
                principalColumn: "FoeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Foes_FoeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_FoeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FoeId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Foes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foes_EventId",
                table: "Foes",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foes_Events_EventId",
                table: "Foes",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
