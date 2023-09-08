using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class once : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAlarms_Users_IdAccount",
                table: "UserAlarms");

            migrationBuilder.DropIndex(
                name: "IX_UserAlarms_IdAccount",
                table: "UserAlarms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserAlarms_IdAccount",
                table: "UserAlarms",
                column: "IdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAlarms_Users_IdAccount",
                table: "UserAlarms",
                column: "IdAccount",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
