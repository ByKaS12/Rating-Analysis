using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class MigFixv10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TournamentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    PlayerPosition = table.Column<string>(type: "TEXT", nullable: true),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimePlayed = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: true),
                    Assists = table.Column<int>(type: "INTEGER", nullable: false),
                    Steals = table.Column<int>(type: "INTEGER", nullable: false),
                    Losses = table.Column<int>(type: "INTEGER", nullable: false),
                    Blockshots = table.Column<int>(type: "INTEGER", nullable: false),
                    Fouls = table.Column<int>(type: "INTEGER", nullable: false),
                    FoulsOfEnemy = table.Column<int>(type: "INTEGER", nullable: false),
                    PlusMinus = table.Column<int>(type: "INTEGER", nullable: false),
                    KPI = table.Column<int>(type: "INTEGER", nullable: false),
                    CalcUPer = table.Column<double>(type: "REAL", nullable: false),
                    CalcPace = table.Column<double>(type: "REAL", nullable: false),
                    CalcHollinger = table.Column<double>(type: "REAL", nullable: false),
                    CalcTPA = table.Column<double>(type: "REAL", nullable: false),
                    CalcEFGProcent = table.Column<double>(type: "REAL", nullable: false),
                    CalcTSProcent = table.Column<double>(type: "REAL", nullable: false),
                    CalcOffRating = table.Column<double>(type: "REAL", nullable: false),
                    CalcDefRating = table.Column<double>(type: "REAL", nullable: false),
                    PlayerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rebounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RebOfAlien = table.Column<int>(type: "INTEGER", nullable: false),
                    RebOfOwn = table.Column<int>(type: "INTEGER", nullable: false),
                    AllReb = table.Column<int>(type: "INTEGER", nullable: false),
                    StatisticId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StatisticId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rebounds_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rebounds_Statistics_StatisticId1",
                        column: x => x.StatisticId1,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TwoPointScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    TwoPointAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ThreePointScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ThreePointAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FreeThrowsScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FreeThrowsAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldGoalsAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldGoalsScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    StatisticId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StatisticId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoots_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoots_Statistics_StatisticId1",
                        column: x => x.StatisticId1,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TournamentId",
                table: "Games",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebounds_StatisticId",
                table: "Rebounds",
                column: "StatisticId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rebounds_StatisticId1",
                table: "Rebounds",
                column: "StatisticId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shoots_StatisticId",
                table: "Shoots",
                column: "StatisticId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoots_StatisticId1",
                table: "Shoots",
                column: "StatisticId1");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_PlayerId",
                table: "Statistics",
                column: "PlayerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rebounds");

            migrationBuilder.DropTable(
                name: "Shoots");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
