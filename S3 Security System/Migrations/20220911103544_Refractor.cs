using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3_Security_System.Migrations
{
    public partial class Refractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_StaffCityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_StudentCityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Position_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Province_StaffProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Province_StudentProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Registor_RegistorID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Breach_AspNetUsers_StaffId",
                table: "Breach");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceToken_AspNetUsers_security_systemId",
                table: "EntranceToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Registor_AspNetUsers_TeacherId",
                table: "Registor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegistorID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StaffCityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StaffProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentCityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentGrade",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParentEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffCityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffDateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffNextOfKinContactName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffNextOfKinContactNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffZip",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentCityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentDateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentNextOfKinContactName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentNextOfKinContactNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentZip",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VisitReason",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VisitorFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VisitorLastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "security_systemId",
                table: "EntranceToken",
                newName: "S3_Security_SystemUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EntranceToken_security_systemId",
                table: "EntranceToken",
                newName: "IX_EntranceToken_S3_Security_SystemUserId");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "AspNetUsers",
                newName: "Role");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Registor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Breach",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S3_Security_SystemUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StaffDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffCityId = table.Column<int>(type: "int", nullable: true),
                    StaffProvinceId = table.Column<int>(type: "int", nullable: true),
                    StaffZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffNextOfKinContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffNextOfKinContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staff_AspNetUsers_S3_Security_SystemUserId",
                        column: x => x.S3_Security_SystemUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_City_StaffCityId",
                        column: x => x.StaffCityId,
                        principalTable: "City",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Staff_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Province_StaffProvinceId",
                        column: x => x.StaffProvinceId,
                        principalTable: "Province",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S3_Security_SystemUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentGrade = table.Column<int>(type: "int", nullable: false),
                    StudentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCityId = table.Column<int>(type: "int", nullable: true),
                    StudentProvinceId = table.Column<int>(type: "int", nullable: true),
                    StudentZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNextOfKinContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNextOfKinContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_S3_Security_SystemUserId",
                        column: x => x.S3_Security_SystemUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_City_StudentCityId",
                        column: x => x.StudentCityId,
                        principalTable: "City",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Students_Province_StudentProvinceId",
                        column: x => x.StudentProvinceId,
                        principalTable: "Province",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Students_Registor_RegistorID",
                        column: x => x.RegistorID,
                        principalTable: "Registor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S3_Security_SystemUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Visitors_AspNetUsers_S3_Security_SystemUserId",
                        column: x => x.S3_Security_SystemUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PositionId",
                table: "Staff",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_S3_Security_SystemUserId",
                table: "Staff",
                column: "S3_Security_SystemUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffCityId",
                table: "Staff",
                column: "StaffCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffProvinceId",
                table: "Staff",
                column: "StaffProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RegistorID",
                table: "Students",
                column: "RegistorID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_S3_Security_SystemUserId",
                table: "Students",
                column: "S3_Security_SystemUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentCityId",
                table: "Students",
                column: "StudentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentProvinceId",
                table: "Students",
                column: "StudentProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_S3_Security_SystemUserId",
                table: "Visitors",
                column: "S3_Security_SystemUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Breach_Staff_StaffId",
                table: "Breach",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceToken_AspNetUsers_S3_Security_SystemUserId",
                table: "EntranceToken",
                column: "S3_Security_SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registor_Staff_TeacherId",
                table: "Registor",
                column: "TeacherId",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breach_Staff_StaffId",
                table: "Breach");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceToken_AspNetUsers_S3_Security_SystemUserId",
                table: "EntranceToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Registor_Staff_TeacherId",
                table: "Registor");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.RenameColumn(
                name: "S3_Security_SystemUserId",
                table: "EntranceToken",
                newName: "security_systemId");

            migrationBuilder.RenameIndex(
                name: "IX_EntranceToken_S3_Security_SystemUserId",
                table: "EntranceToken",
                newName: "IX_EntranceToken_security_systemId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AspNetUsers",
                newName: "Discriminator");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Registor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "Breach",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CurrentGrade",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistorID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffCityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StaffDateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffNextOfKinContactName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffNextOfKinContactNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffProvinceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffZip",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentCityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentDateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentNextOfKinContactName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentNextOfKinContactNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentProvinceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentZip",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitReason",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitorFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitorLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegistorID",
                table: "AspNetUsers",
                column: "RegistorID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffCityId",
                table: "AspNetUsers",
                column: "StaffCityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffProvinceId",
                table: "AspNetUsers",
                column: "StaffProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentCityId",
                table: "AspNetUsers",
                column: "StudentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentProvinceId",
                table: "AspNetUsers",
                column: "StudentProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City_StaffCityId",
                table: "AspNetUsers",
                column: "StaffCityId",
                principalTable: "City",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City_StudentCityId",
                table: "AspNetUsers",
                column: "StudentCityId",
                principalTable: "City",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Position_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Province_StaffProvinceId",
                table: "AspNetUsers",
                column: "StaffProvinceId",
                principalTable: "Province",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Province_StudentProvinceId",
                table: "AspNetUsers",
                column: "StudentProvinceId",
                principalTable: "Province",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Registor_RegistorID",
                table: "AspNetUsers",
                column: "RegistorID",
                principalTable: "Registor",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breach_AspNetUsers_StaffId",
                table: "Breach",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceToken_AspNetUsers_security_systemId",
                table: "EntranceToken",
                column: "security_systemId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registor_AspNetUsers_TeacherId",
                table: "Registor",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
