using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class UpdatedPilotStewardessColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Stewardesses",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stewardesses",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Pilots",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pilots",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Stewardesses",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Stewardesses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Pilots",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Pilots",
                newName: "Name");
        }
    }
}
