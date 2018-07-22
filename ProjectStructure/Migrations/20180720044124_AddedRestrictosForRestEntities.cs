using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class AddedRestrictosForRestEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Tickets",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaneModel",
                table: "PlaneTypes",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationAirport",
                table: "Flights",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureAirport",
                table: "Flights",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Departures",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "PlaneModel",
                table: "PlaneTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationAirport",
                table: "Flights",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureAirport",
                table: "Flights",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Departures",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6);
        }
    }
}
