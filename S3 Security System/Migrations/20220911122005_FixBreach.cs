using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class FixBreach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breach_Staff_StaffId",
                table: "Breach");

            migrationBuilder.DropIndex(
                name: "IX_Breach_StaffId",
                table: "Breach");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Breach");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfExit",
                table: "EntranceToken",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfEntry",
                table: "EntranceToken",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Breach",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Breach_S3_Security_SystemUserId",
                table: "Breach",
                column: "S3_Security_SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breach_AspNetUsers_S3_Security_SystemUserId",
                table: "Breach",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breach_AspNetUsers_S3_Security_SystemUserId",
                table: "Breach");

            migrationBuilder.DropIndex(
                name: "IX_Breach_S3_Security_SystemUserId",
                table: "Breach");

            migrationBuilder.DropColumn(
                name: "S3_Security_SystemUserId",
                table: "Breach");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfExit",
                table: "EntranceToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfEntry",
                table: "EntranceToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Breach",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Breach_StaffId",
                table: "Breach",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breach_Staff_StaffId",
                table: "Breach",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
