using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_25_Süper_Lig_Kit.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    RefereeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefereeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFifa = table.Column<bool>(type: "bit", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.RefereeId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Jerseys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    IsKeeper = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jerseys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jerseys_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JerseyImages",
                columns: table => new
                {
                    JerseyImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JerseyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseyImages", x => x.JerseyImageId);
                    table.ForeignKey(
                        name: "FK_JerseyImages_Jerseys_JerseyId",
                        column: x => x.JerseyId,
                        principalTable: "Jerseys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamJerseyImageId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamJerseyImageGKId = table.Column<int>(type: "int", nullable: false),
                    RefereeJerseyImageId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamJerseyImageId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamJerseyImageGKId = table.Column<int>(type: "int", nullable: false),
                    HomeMS = table.Column<int>(type: "int", nullable: true),
                    AwayMS = table.Column<int>(type: "int", nullable: true),
                    Maçkolik = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MainId = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    RefereeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_JerseyImages_AwayTeamJerseyImageGKId",
                        column: x => x.AwayTeamJerseyImageGKId,
                        principalTable: "JerseyImages",
                        principalColumn: "JerseyImageId");
                    table.ForeignKey(
                        name: "FK_Matches_JerseyImages_AwayTeamJerseyImageId",
                        column: x => x.AwayTeamJerseyImageId,
                        principalTable: "JerseyImages",
                        principalColumn: "JerseyImageId");
                    table.ForeignKey(
                        name: "FK_Matches_JerseyImages_HomeTeamJerseyImageGKId",
                        column: x => x.HomeTeamJerseyImageGKId,
                        principalTable: "JerseyImages",
                        principalColumn: "JerseyImageId");
                    table.ForeignKey(
                        name: "FK_Matches_JerseyImages_HomeTeamJerseyImageId",
                        column: x => x.HomeTeamJerseyImageId,
                        principalTable: "JerseyImages",
                        principalColumn: "JerseyImageId");
                    table.ForeignKey(
                        name: "FK_Matches_JerseyImages_RefereeJerseyImageId",
                        column: x => x.RefereeJerseyImageId,
                        principalTable: "JerseyImages",
                        principalColumn: "JerseyImageId");
                    table.ForeignKey(
                        name: "FK_Matches_Referees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referees",
                        principalColumn: "RefereeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JerseyImages_JerseyId",
                table: "JerseyImages",
                column: "JerseyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jerseys_TeamId",
                table: "Jerseys",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamJerseyImageGKId",
                table: "Matches",
                column: "AwayTeamJerseyImageGKId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamJerseyImageId",
                table: "Matches",
                column: "AwayTeamJerseyImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamJerseyImageGKId",
                table: "Matches",
                column: "HomeTeamJerseyImageGKId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamJerseyImageId",
                table: "Matches",
                column: "HomeTeamJerseyImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeId",
                table: "Matches",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeJerseyImageId",
                table: "Matches",
                column: "RefereeJerseyImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "JerseyImages");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "Jerseys");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
