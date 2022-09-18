using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class EntranceToken2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntranceToken_AspNetUsers_S3_Security_SystemUserId",
                table: "EntranceToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Registor_AspNetUsers_S3_Security_SystemUserId",
                table: "Registor");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Registor",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "EntranceToken",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateObtained",
                table: "EntranceToken",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceToken_AspNetUsers_S3_Security_SystemUserId",
                table: "EntranceToken",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registor_AspNetUsers_S3_Security_SystemUserId",
                table: "Registor",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntranceToken_AspNetUsers_S3_Security_SystemUserId",
                table: "EntranceToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Registor_AspNetUsers_S3_Security_SystemUserId",
                table: "Registor");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Registor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "EntranceToken",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateObtained",
                table: "EntranceToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceToken_AspNetUsers_S3_Security_SystemUserId",
                table: "EntranceToken",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registor_AspNetUsers_S3_Security_SystemUserId",
                table: "Registor",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
