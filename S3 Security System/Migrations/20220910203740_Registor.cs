using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class Registor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistorID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntranceToken",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateObtained = table.Column<DateTime>(type: "datetime2", nullable: false),
                    security_systemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessGranted = table.Column<bool>(type: "bit", nullable: false),
                    TimeOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfExit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EntranceToken_AspNetUsers_security_systemId",
                        column: x => x.security_systemId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registor_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegistorID",
                table: "AspNetUsers",
                column: "RegistorID");

            migrationBuilder.CreateIndex(
                name: "IX_EntranceToken_security_systemId",
                table: "EntranceToken",
                column: "security_systemId");

            migrationBuilder.CreateIndex(
                name: "IX_Registor_TeacherId",
                table: "Registor",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Registor_RegistorID",
                table: "AspNetUsers",
                column: "RegistorID",
                principalTable: "Registor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Registor_RegistorID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EntranceToken");

            migrationBuilder.DropTable(
                name: "Registor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegistorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistorID",
                table: "AspNetUsers");
        }
    }
}
