using Microsoft.EntityFrameworkCore.Migrations;

namespace HGH_Webesite.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "HomePage",
                newName: "name3");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "HomePage",
                newName: "name2");

            migrationBuilder.AddColumn<string>(
                name: "img2",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img3",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgtitle",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name1",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img2",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "img3",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "imgtitle",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "name1",
                table: "HomePage");

            migrationBuilder.RenameColumn(
                name: "name3",
                table: "HomePage",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "name2",
                table: "HomePage",
                newName: "img");
        }
    }
}
