using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Migrations
{
    public partial class ChangedPlanesPlaneTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_PlaneTypeId",
                table: "Planes");

            migrationBuilder.AlterColumn<int>(
                name: "PlaneTypeId",
                table: "Planes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlaneTypeId",
                table: "Planes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PlaneTypeId",
                table: "Planes",
                column: "PlaneTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes",
                column: "PlaneTypeId",
                principalTable: "PlaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
