using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class CreatedRelationsCrewPilotStewardess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Pilots_PilotId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses");

            migrationBuilder.DropIndex(
                name: "IX_Crews_PilotId",
                table: "Crews");

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Stewardesses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PilotId",
                table: "Crews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PilotId",
                table: "Crews",
                column: "PilotId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Pilots_PilotId",
                table: "Crews",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Pilots_PilotId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses");

            migrationBuilder.DropIndex(
                name: "IX_Crews_PilotId",
                table: "Crews");

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Stewardesses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PilotId",
                table: "Crews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PilotId",
                table: "Crews",
                column: "PilotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Pilots_PilotId",
                table: "Crews",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
