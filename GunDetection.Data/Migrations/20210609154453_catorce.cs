using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GunDetection.Data.Migrations
{
    public partial class catorce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Alerts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdAccount",
                table: "Alerts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Alerts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IdAccount",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Alerts");
        }
    }
}
