using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
