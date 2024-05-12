using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimePlayed = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    Assists = table.Column<int>(type: "INTEGER", nullable: false),
                    Steals = table.Column<int>(type: "INTEGER", nullable: false),
                    Losses = table.Column<int>(type: "INTEGER", nullable: false),
                    Blockshots = table.Column<int>(type: "INTEGER", nullable: false),
                    Fouls = table.Column<int>(type: "INTEGER", nullable: false),
                    FoulsOfEnemy = table.Column<int>(type: "INTEGER", nullable: false),
                    PlusMinus = table.Column<int>(type: "INTEGER", nullable: false),
                    KPI = table.Column<int>(type: "INTEGER", nullable: false),
                    CalcHollinger = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
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
                name: "Rebound",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RebOfAlien = table.Column<int>(type: "INTEGER", nullable: false),
                    RebOfOwn = table.Column<int>(type: "INTEGER", nullable: false),
                    AllReb = table.Column<int>(type: "INTEGER", nullable: false),
                    StatisticId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rebound_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TwoPointScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    TwoPointAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ThreePointScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ThreePointAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FreeThrowsScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FreeThrowsAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldGoalsScoredPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldGoalsAllPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    StatisticId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoot_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TournamentId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    PlayerPosition = table.Column<string>(type: "TEXT", nullable: false),
                    StatisticId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                        name: "FK_Players_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Players_StatisticId",
                table: "Players",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebound_StatisticId",
                table: "Rebound",
                column: "StatisticId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoot_StatisticId",
                table: "Shoot",
                column: "StatisticId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rebound");

            migrationBuilder.DropTable(
                name: "Shoot");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
