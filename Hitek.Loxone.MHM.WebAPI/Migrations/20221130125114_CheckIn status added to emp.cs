using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hitek.Loxone.MHM.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CheckInstatusaddedtoemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedIn",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedIn",
                table: "Employees");
        }
    }
}
