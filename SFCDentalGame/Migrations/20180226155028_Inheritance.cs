using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SFCDentalGame.Migrations
{
    public partial class Inheritance : Migration
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
                name: "DentalHealth",
                columns: table => new
                {
                    DentalHealthId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    PracticeSubmitTime = table.Column<DateTime>(nullable: false),
                    TeethAge = table.Column<decimal>(nullable: false),
                    TotalScore = table.Column<decimal>(nullable: false)
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
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Discriminator = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Points = table.Column<decimal>(nullable: false),
                    ProffesionalComment = table.Column<string>(nullable: true),
                    ratings = table.Column<int>(nullable: false),
                    LongerPractices = table.Column<int>(nullable: true),
                    OtherSupporting = table.Column<int>(nullable: true),
                    UsageBehaviour = table.Column<int>(nullable: true),
                    Range = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DentalHealthId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profile_DentalHealth_DentalHealthId",
                        column: x => x.DentalHealthId,
                        principalTable: "DentalHealth",
                        principalColumn: "DentalHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    FrequencyId = table.Column<int>(nullable: false),
                    BehaviourWithFreqBehaviourId = table.Column<int>(nullable: true),
                    FrequencyName = table.Column<string>(nullable: true),
                    LongerPractices = table.Column<int>(nullable: true),
                    OtherSupporting = table.Column<int>(nullable: true),
                    UsageBehaviour = table.Column<int>(nullable: true),
                    points = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => x.FrequencyId);
                    table.ForeignKey(
                        name: "FK_Frequency_Behaviour_BehaviourWithFreqBehaviourId",
                        column: x => x.BehaviourWithFreqBehaviourId,
                        principalTable: "Behaviour",
                        principalColumn: "BehaviourId",
                        onDelete: ReferentialAction.Restrict);
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
                });

            migrationBuilder.CreateTable(
                name: "PracticeItem",
                columns: table => new
                {
                    DentalPracticeItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BehaviourId = table.Column<int>(nullable: true),
                    DentalPracticeId = table.Column<string>(nullable: true),
                    FrequencyName = table.Column<string>(nullable: true),
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
                name: "IX_Behaviour_CategoryId",
                table: "Behaviour",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequency_BehaviourWithFreqBehaviourId",
                table: "Frequency",
                column: "BehaviourWithFreqBehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthDetail_BehaviourId",
                table: "HealthDetail",
                column: "BehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthDetail_DentalHealthId",
                table: "HealthDetail",
                column: "DentalHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeItem_BehaviourId",
                table: "PracticeItem",
                column: "BehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_DentalHealthId",
                table: "Profile",
                column: "DentalHealthId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "HealthDetail");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PracticeItem");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Behaviour");

            migrationBuilder.DropTable(
                name: "DentalHealth");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
