using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIs.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lk.Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DepartmentEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk.Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lk.Gender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenderEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk.Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "01_Employees",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Department_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Gender_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_01_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_01_Employees_Lk.Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Lk.Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_01_Employees_Lk.Gender_Gender_ID",
                        column: x => x.Gender_ID,
                        principalTable: "Lk.Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_01_Employees_DepartmentID",
                table: "01_Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_01_Employees_Gender_ID",
                table: "01_Employees",
                column: "Gender_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "01_Employees");

            migrationBuilder.DropTable(
                name: "Lk.Department");

            migrationBuilder.DropTable(
                name: "Lk.Gender");
        }
    }
}
