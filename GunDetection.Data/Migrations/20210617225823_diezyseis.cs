using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class diezyseis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Clip",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Msg",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_alarm",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clip",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Msg",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Name_alarm",
                table: "Alerts");
        }
    }
}
