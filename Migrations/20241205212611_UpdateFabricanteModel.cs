using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFabricanteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabricante_Grupo_Id_grupo",
                table: "Fabricante");

            migrationBuilder.AlterColumn<int>(
                name: "Pais",
                table: "Fabricante",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Id_grupo",
                table: "Fabricante",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Año_fundacion",
                table: "Fabricante",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Fabricante_Grupo_Id_grupo",
                table: "Fabricante",
                column: "Id_grupo",
                principalTable: "Grupo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabricante_Grupo_Id_grupo",
                table: "Fabricante");

            migrationBuilder.AlterColumn<int>(
                name: "Pais",
                table: "Fabricante",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id_grupo",
                table: "Fabricante",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Año_fundacion",
                table: "Fabricante",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fabricante_Grupo_Id_grupo",
                table: "Fabricante",
                column: "Id_grupo",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
