using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomMag.Migrations
{
    /// <inheritdoc />
    public partial class MixFixV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CalcPace",
                table: "Statistic",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalcPace",
                table: "Statistic");
        }
    }
}
