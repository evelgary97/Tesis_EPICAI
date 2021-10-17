using Microsoft.EntityFrameworkCore.Migrations;

namespace Tesis_EPICAI.Migrations
{
    public partial class cargoFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajador_Cargo_CargoId",
                table: "Trabajador");

            migrationBuilder.AlterColumn<int>(
                name: "CargoId",
                table: "Trabajador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajador_Cargo_CargoId",
                table: "Trabajador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajador_Cargo_CargoId",
                table: "Trabajador");

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
    }
}
