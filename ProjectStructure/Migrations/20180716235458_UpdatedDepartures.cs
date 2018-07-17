using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class UpdatedDepartures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures");

            migrationBuilder.DropIndex(
                name: "IX_Departures_CrewId",
                table: "Departures");

            migrationBuilder.DropIndex(
                name: "IX_Departures_PlaneId",
                table: "Departures");

            migrationBuilder.AlterColumn<int>(
                name: "PlaneId",
                table: "Departures",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Departures",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Departures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departures_CrewId",
                table: "Departures",
                column: "CrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departures_FlightId",
                table: "Departures",
                column: "FlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departures_PlaneId",
                table: "Departures",
                column: "PlaneId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Flights_FlightId",
                table: "Departures",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Flights_FlightId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures");

            migrationBuilder.DropIndex(
                name: "IX_Departures_CrewId",
                table: "Departures");

            migrationBuilder.DropIndex(
                name: "IX_Departures_FlightId",
                table: "Departures");

            migrationBuilder.DropIndex(
                name: "IX_Departures_PlaneId",
                table: "Departures");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Departures");

            migrationBuilder.AlterColumn<int>(
                name: "PlaneId",
                table: "Departures",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Departures",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Departures_CrewId",
                table: "Departures",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_PlaneId",
                table: "Departures",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
