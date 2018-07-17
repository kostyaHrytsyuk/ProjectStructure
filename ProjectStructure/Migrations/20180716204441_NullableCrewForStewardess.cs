using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class NullableCrewForStewardess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses");

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Stewardesses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses");

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Stewardesses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
