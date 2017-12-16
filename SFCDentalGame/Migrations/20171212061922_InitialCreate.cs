using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SFCDentalGame.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryDescription = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Behaviour",
                columns: table => new
                {
                    BehaviourId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BehaviourDescription = table.Column<string>(nullable: true),
                    BehaviourName = table.Column<string>(nullable: true),
                    BehaviourType = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: true),
                    InPractice = table.Column<bool>(nullable: false),
                    Points = table.Column<double>(nullable: false),
                    value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behaviour", x => x.BehaviourId);
                    table.ForeignKey(
                        name: "FK_Behaviour_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Behaviour_CategoryId",
                table: "Behaviour",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Behaviour");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
