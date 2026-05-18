using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbSense.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Staff_StaffInfoId",
                table: "Holiday");

            migrationBuilder.DropForeignKey(
                name: "FK_HolidayBalance_Holiday_HolidayInfoId",
                table: "HolidayBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holiday",
                table: "Holiday");

            migrationBuilder.RenameTable(
                name: "Holiday",
                newName: "HolidayInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Holiday_StaffInfoId",
                table: "HolidayInfo",
                newName: "IX_HolidayInfo_StaffInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HolidayInfo",
                table: "HolidayInfo",
                column: "HolidayInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayBalance_HolidayInfo_HolidayInfoId",
                table: "HolidayBalance",
                column: "HolidayInfoId",
                principalTable: "HolidayInfo",
                principalColumn: "HolidayInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayInfo_Staff_StaffInfoId",
                table: "HolidayInfo",
                column: "StaffInfoId",
                principalTable: "Staff",
                principalColumn: "StaffInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayBalance_HolidayInfo_HolidayInfoId",
                table: "HolidayBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_HolidayInfo_Staff_StaffInfoId",
                table: "HolidayInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HolidayInfo",
                table: "HolidayInfo");

            migrationBuilder.RenameTable(
                name: "HolidayInfo",
                newName: "Holiday");

            migrationBuilder.RenameIndex(
                name: "IX_HolidayInfo_StaffInfoId",
                table: "Holiday",
                newName: "IX_Holiday_StaffInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holiday",
                table: "Holiday",
                column: "HolidayInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Staff_StaffInfoId",
                table: "Holiday",
                column: "StaffInfoId",
                principalTable: "Staff",
                principalColumn: "StaffInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayBalance_Holiday_HolidayInfoId",
                table: "HolidayBalance",
                column: "HolidayInfoId",
                principalTable: "Holiday",
                principalColumn: "HolidayInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
