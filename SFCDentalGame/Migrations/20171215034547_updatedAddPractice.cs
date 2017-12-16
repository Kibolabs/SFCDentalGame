using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SFCDentalGame.Migrations
{
    public partial class updatedAddPractice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DentalPracticeId",
                table: "PracticeItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "DentalHealth",
                columns: table => new
                {
                    DentalHealthId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Score = table.Column<decimal>(nullable: false),
                    TeethAge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentalHealth", x => x.DentalHealthId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "HealthDetail",
                columns: table => new
                {
                    DentalHealthDetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BehaviourId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DentalHealthId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Points = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthDetail", x => x.DentalHealthDetailId);
                    table.ForeignKey(
                        name: "FK_HealthDetail_Behaviour_BehaviourId",
                        column: x => x.BehaviourId,
                        principalTable: "Behaviour",
                        principalColumn: "BehaviourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthDetail_DentalHealth_DentalHealthId",
                        column: x => x.DentalHealthId,
                        principalTable: "DentalHealth",
                        principalColumn: "DentalHealthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthDetail_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthDetail_BehaviourId",
                table: "HealthDetail",
                column: "BehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthDetail_DentalHealthId",
                table: "HealthDetail",
                column: "DentalHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthDetail_PlayerId",
                table: "HealthDetail",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthDetail");

            migrationBuilder.DropTable(
                name: "DentalHealth");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "DentalPracticeId",
                table: "PracticeItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
