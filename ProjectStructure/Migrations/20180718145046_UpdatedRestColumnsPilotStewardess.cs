using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class UpdatedRestColumnsPilotStewardess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Stewardesses",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Pilots",
                newName: "Exp");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Pilots",
                newName: "BirthDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Stewardesses",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Exp",
                table: "Pilots",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Pilots",
                newName: "DateOfBirth");
        }
    }
}
