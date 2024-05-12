using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class MigFixV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Statistic_StatisticId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "StatisticId",
                table: "Players",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_StatisticId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "Statistic",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_PlayerId",
                table: "Statistic",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_Players_PlayerId",
                table: "Statistic",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_Players_PlayerId",
                table: "Statistic");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Statistic_PlayerId",
                table: "Statistic");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Statistic");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Players",
                newName: "StatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                newName: "IX_Players_StatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Statistic_StatisticId",
                table: "Players",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
