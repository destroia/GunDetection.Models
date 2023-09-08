using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class quince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Figth",
                table: "UserAlarms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GunDetected",
                table: "UserAlarms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HandsUp",
                table: "UserAlarms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PersonDetection",
                table: "UserAlarms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Figth",
                table: "UserAlarms");

            migrationBuilder.DropColumn(
                name: "GunDetected",
                table: "UserAlarms");

            migrationBuilder.DropColumn(
                name: "HandsUp",
                table: "UserAlarms");

            migrationBuilder.DropColumn(
                name: "PersonDetection",
                table: "UserAlarms");
        }
    }
}
