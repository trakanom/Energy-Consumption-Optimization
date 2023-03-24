using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyConsumptionOptimization.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "EnergyUsages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "EnergyUsages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "EnergyUsages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PowerConsumption",
                table: "Devices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyUsages_DeviceId",
                table: "EnergyUsages",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyUsages_Devices_DeviceId",
                table: "EnergyUsages",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnergyUsages_Devices_DeviceId",
                table: "EnergyUsages");

            migrationBuilder.DropIndex(
                name: "IX_EnergyUsages_DeviceId",
                table: "EnergyUsages");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "EnergyUsages");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EnergyUsages");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "EnergyUsages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "PowerConsumption",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");
        }
    }
}
