using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Users");
        }
    }
}
