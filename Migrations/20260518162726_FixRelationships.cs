using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbSense.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayBalance_HolidayInfo_HolidayInfoId",
                table: "HolidayBalance");

            migrationBuilder.DropIndex(
                name: "IX_HolidayBalance_HolidayInfoId",
                table: "HolidayBalance");

            migrationBuilder.DropColumn(
                name: "AllowedLeaves",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Staff",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "HolidayInfoId",
                table: "HolidayBalance",
                newName: "TotalAllowance");

            migrationBuilder.RenameColumn(
                name: "AnnualAllowance",
                table: "HolidayBalance",
                newName: "StaffInfoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "HolidayInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "HolidayInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByStaffInfoId",
                table: "HolidayInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HolidayBalance_StaffInfoId",
                table: "HolidayBalance",
                column: "StaffInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayBalance_Staff_StaffInfoId",
                table: "HolidayBalance",
                column: "StaffInfoId",
                principalTable: "Staff",
                principalColumn: "StaffInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayBalance_Staff_StaffInfoId",
                table: "HolidayBalance");

            migrationBuilder.DropIndex(
                name: "IX_HolidayBalance_StaffInfoId",
                table: "HolidayBalance");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "HolidayInfo");

            migrationBuilder.DropColumn(
                name: "ApprovedByStaffInfoId",
                table: "HolidayInfo");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Staff",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "TotalAllowance",
                table: "HolidayBalance",
                newName: "HolidayInfoId");

            migrationBuilder.RenameColumn(
                name: "StaffInfoId",
                table: "HolidayBalance",
                newName: "AnnualAllowance");

            migrationBuilder.AddColumn<int>(
                name: "AllowedLeaves",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "HolidayInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HolidayBalance_HolidayInfoId",
                table: "HolidayBalance",
                column: "HolidayInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayBalance_HolidayInfo_HolidayInfoId",
                table: "HolidayBalance",
                column: "HolidayInfoId",
                principalTable: "HolidayInfo",
                principalColumn: "HolidayInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
