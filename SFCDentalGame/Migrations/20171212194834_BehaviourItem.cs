using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SFCDentalGame.Migrations
{
    public partial class BehaviourItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PracticeItem",
                columns: table => new
                {
                    DentalPracticeItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BehaviourId = table.Column<int>(nullable: true),
                    DentalPracticeId = table.Column<int>(nullable: false),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeItem", x => x.DentalPracticeItemID);
                    table.ForeignKey(
                        name: "FK_PracticeItem_Behaviour_BehaviourId",
                        column: x => x.BehaviourId,
                        principalTable: "Behaviour",
                        principalColumn: "BehaviourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PracticeItem_BehaviourId",
                table: "PracticeItem",
                column: "BehaviourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PracticeItem");
        }
    }
}
