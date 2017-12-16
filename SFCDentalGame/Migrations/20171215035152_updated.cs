using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SFCDentalGame.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthDetail_Player_PlayerId",
                table: "HealthDetail");

            migrationBuilder.DropIndex(
                name: "IX_HealthDetail_PlayerId",
                table: "HealthDetail");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "HealthDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "HealthDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HealthDetail_PlayerId",
                table: "HealthDetail",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthDetail_Player_PlayerId",
                table: "HealthDetail",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
