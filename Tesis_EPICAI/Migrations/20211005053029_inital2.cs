using Microsoft.EntityFrameworkCore.Migrations;

namespace Tesis_EPICAI.Migrations
{
    public partial class inital2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajador_Cargo_CargoID",
                table: "Trabajador");

            migrationBuilder.RenameColumn(
                name: "CargoID",
                table: "Trabajador",
                newName: "CargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Trabajador_CargoID",
                table: "Trabajador",
                newName: "IX_Trabajador_CargoId");

            migrationBuilder.AlterColumn<int>(
                name: "CargoId",
                table: "Trabajador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajador_Cargo_CargoId",
                table: "Trabajador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajador_Cargo_CargoId",
                table: "Trabajador");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "Trabajador",
                newName: "CargoID");

            migrationBuilder.RenameIndex(
                name: "IX_Trabajador_CargoId",
                table: "Trabajador",
                newName: "IX_Trabajador_CargoID");

            migrationBuilder.AlterColumn<int>(
                name: "CargoID",
                table: "Trabajador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajador_Cargo_CargoID",
                table: "Trabajador",
                column: "CargoID",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
