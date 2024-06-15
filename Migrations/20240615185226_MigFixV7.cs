using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class MigFixV7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CalcDefRating",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CalcEFGProcent",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CalcOffRating",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CalcTPA",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CalcTSProcent",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalcDefRating",
                table: "Statistic");

            migrationBuilder.DropColumn(
                name: "CalcEFGProcent",
                table: "Statistic");

            migrationBuilder.DropColumn(
                name: "CalcOffRating",
                table: "Statistic");

            migrationBuilder.DropColumn(
                name: "CalcTPA",
                table: "Statistic");

            migrationBuilder.DropColumn(
                name: "CalcTSProcent",
                table: "Statistic");
        }
    }
}
