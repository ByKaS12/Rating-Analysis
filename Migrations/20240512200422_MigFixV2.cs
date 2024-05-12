using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class MigFixV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CalcUPer",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalcUPer",
                table: "Statistic");
        }
    }
}
