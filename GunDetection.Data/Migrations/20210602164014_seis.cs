using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class seis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubLocations_Locations_IdLocation",
                table: "SubLocations");

            migrationBuilder.DropIndex(
                name: "IX_SubLocations_IdLocation",
                table: "SubLocations");

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSubLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Locations_IdLocation",
                        column: x => x.IdLocation,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cameras_SubLocations_IdSubLocation",
                        column: x => x.IdSubLocation,
                        principalTable: "SubLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_IdLocation",
                table: "Cameras",
                column: "IdLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_IdSubLocation",
                table: "Cameras",
                column: "IdSubLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cameras");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
