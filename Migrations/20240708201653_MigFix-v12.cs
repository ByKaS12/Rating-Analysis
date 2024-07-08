using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class MigFixv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rebounds_Statistics_StatisticId1",
                table: "Rebounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoots_Statistics_StatisticId1",
                table: "Shoots");

            migrationBuilder.DropIndex(
                name: "IX_Shoots_StatisticId1",
                table: "Shoots");

            migrationBuilder.DropIndex(
                name: "IX_Rebounds_StatisticId1",
                table: "Rebounds");

            migrationBuilder.DropColumn(
                name: "StatisticId1",
                table: "Shoots");

            migrationBuilder.DropColumn(
                name: "StatisticId1",
                table: "Rebounds");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AllReb",
                table: "Rebounds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "AllReb",
                table: "Rebounds");

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticId1",
                table: "Shoots",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticId1",
                table: "Rebounds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoots_StatisticId1",
                table: "Shoots",
                column: "StatisticId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rebounds_StatisticId1",
                table: "Rebounds",
                column: "StatisticId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rebounds_Statistics_StatisticId1",
                table: "Rebounds",
                column: "StatisticId1",
                principalTable: "Statistics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoots_Statistics_StatisticId1",
                table: "Shoots",
                column: "StatisticId1",
                principalTable: "Statistics",
                principalColumn: "Id");
        }
    }
}
