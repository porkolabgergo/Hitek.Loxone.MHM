using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hitek.Loxone.MHM.WebAPI.Migrations.LogRecord
{
    /// <inheritdoc />
    public partial class Changs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogRecords_Employee_EmployeeID",
                table: "LogRecords");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_LogRecords_EmployeeID",
                table: "LogRecords");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "LogRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "LogRecords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogRecords_EmployeeID",
                table: "LogRecords",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogRecords_Employee_EmployeeID",
                table: "LogRecords",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");
        }
    }
}
