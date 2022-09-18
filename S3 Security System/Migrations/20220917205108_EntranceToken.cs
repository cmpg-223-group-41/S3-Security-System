using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class EntranceToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_S3_Security_SystemUserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_S3_Security_SystemUserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_AspNetUsers_S3_Security_SystemUserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_S3_Security_SystemUserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Students_S3_Security_SystemUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Staff_S3_Security_SystemUserId",
                table: "Staff");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Visitors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Staff",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_S3_Security_SystemUserId",
                table: "Visitors",
                column: "S3_Security_SystemUserId",
                unique: true,
                filter: "[S3_Security_SystemUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_S3_Security_SystemUserId",
                table: "Students",
                column: "S3_Security_SystemUserId",
                unique: true,
                filter: "[S3_Security_SystemUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_S3_Security_SystemUserId",
                table: "Staff",
                column: "S3_Security_SystemUserId",
                unique: true,
                filter: "[S3_Security_SystemUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AspNetUsers_S3_Security_SystemUserId",
                table: "Staff",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_S3_Security_SystemUserId",
                table: "Students",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_AspNetUsers_S3_Security_SystemUserId",
                table: "Visitors",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_S3_Security_SystemUserId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_S3_Security_SystemUserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_AspNetUsers_S3_Security_SystemUserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_S3_Security_SystemUserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Students_S3_Security_SystemUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Staff_S3_Security_SystemUserId",
                table: "Staff");

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Visitors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "S3_Security_SystemUserId",
                table: "Staff",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_S3_Security_SystemUserId",
                table: "Visitors",
                column: "S3_Security_SystemUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_S3_Security_SystemUserId",
                table: "Students",
                column: "S3_Security_SystemUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_S3_Security_SystemUserId",
                table: "Staff",
                column: "S3_Security_SystemUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AspNetUsers_S3_Security_SystemUserId",
                table: "Staff",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_S3_Security_SystemUserId",
                table: "Students",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_AspNetUsers_S3_Security_SystemUserId",
                table: "Visitors",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
