using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class cinco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SubLocations_IdLocation",
                table: "SubLocations",
                column: "IdLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_SubLocations_Locations_IdLocation",
                table: "SubLocations",
                column: "IdLocation",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubLocations_Locations_IdLocation",
                table: "SubLocations");

            migrationBuilder.DropIndex(
                name: "IX_SubLocations_IdLocation",
                table: "SubLocations");
        }
    }
}
