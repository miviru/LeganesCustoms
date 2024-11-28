using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddVehiculoIdToFacturaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Factura",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Descuento",
                table: "Factura",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Factura",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

         //   migrationBuilder.AddColumn<long>(
           //     name: "VehiculoId",
             // type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_VehiculoId",
                table: "Factura",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Vehiculo_VehiculoId",
                table: "Factura",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Vehiculo_VehiculoId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_VehiculoId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "Factura",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Descuento",
                table: "Factura",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
