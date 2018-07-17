using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class ChangedPlaneLifeTimeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lifetime",
                table: "Planes");

            migrationBuilder.AddColumn<long>(
                name: "LifeTimeTicks",
                table: "Planes",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LifeTimeTicks",
                table: "Planes");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Lifetime",
                table: "Planes",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
