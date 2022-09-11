using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class FixBreach2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breach_AspNetUsers_S3_Security_SystemUserId",
                table: "Breach");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Breach",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Breach",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Breach_AspNetUsers_S3_Security_SystemUserId",
                table: "Breach",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breach_AspNetUsers_S3_Security_SystemUserId",
                table: "Breach");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Breach",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Breach",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Breach_AspNetUsers_S3_Security_SystemUserId",
                table: "Breach",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
