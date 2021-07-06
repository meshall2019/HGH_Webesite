using Microsoft.EntityFrameworkCore.Migrations;

namespace HGH_Webesite.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BIRTH",
                table: "StatisticsPage",
                newName: "rays");

            migrationBuilder.RenameColumn(
                name: "ARYS",
                table: "StatisticsPage",
                newName: "BRITH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rays",
                table: "StatisticsPage",
                newName: "BIRTH");

            migrationBuilder.RenameColumn(
                name: "BRITH",
                table: "StatisticsPage",
                newName: "ARYS");
        }
    }
}
