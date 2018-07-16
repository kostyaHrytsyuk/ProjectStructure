using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class Reinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    FlightNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "DateOfBirth", "Experience", "Name", "Surname" },
                values: new object[] { 1, new DateTime(1973, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Jimmy", "Doolittle" });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "DateOfBirth", "Experience", "Name", "Surname" },
                values: new object[] { 2, new DateTime(1982, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Noel", "Wien" });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "DateOfBirth", "Experience", "Name", "Surname" },
                values: new object[] { 3, new DateTime(1980, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Robert", "Hoover" });
        }
    }
}
