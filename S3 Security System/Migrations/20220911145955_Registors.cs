using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class Registors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registor_Staff_TeacherId",
                table: "Registor");

            migrationBuilder.DropIndex(
                name: "IX_Registor_TeacherId",
                table: "Registor");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Registor");

            migrationBuilder.AddColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Registor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Registor_S3_Security_SystemUserId",
                table: "Registor",
                column: "S3_Security_SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registor_AspNetUsers_S3_Security_SystemUserId",
                table: "Registor",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registor_AspNetUsers_S3_Security_SystemUserId",
                table: "Registor");

            migrationBuilder.DropIndex(
                name: "IX_Registor_S3_Security_SystemUserId",
                table: "Registor");

            migrationBuilder.DropColumn(
                name: "S3_Security_SystemUserId",
                table: "Registor");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Registor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registor_TeacherId",
                table: "Registor",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registor_Staff_TeacherId",
                table: "Registor",
                column: "TeacherId",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
