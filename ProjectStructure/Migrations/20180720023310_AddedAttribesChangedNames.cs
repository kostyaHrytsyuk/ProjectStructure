using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class AddedAttribesChangedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Stewardesses");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Pilots");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Stewardesses",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Planes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Pilots",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Stewardesses");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Pilots");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Stewardesses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Planes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Pilots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
