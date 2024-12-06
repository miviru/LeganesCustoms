using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class ConsolidatedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Cliente_Id_cliente",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Empleado_Id_empleado",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Persona_Id",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cliente_Id_cliente",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Cliente_Id_cliente",
                table: "Vehiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Personas");

            migrationBuilder.RenameTable(
                name: "Empleado",
                newName: "Empleados");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.AlterColumn<long>(
                name: "Id_cliente",
                table: "Vehiculo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AddColumn<long>(
                name: "VehiculoId",
                table: "Factura",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Puesto",
                table: "Empleados",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Empleado",
                table: "Empleados",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Cliente",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_VehiculoId",
                table: "Factura",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Clientes_Id_cliente",
                table: "Cita",
                column: "Id_cliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Empleados_Id_empleado",
                table: "Cita",
                column: "Id_empleado",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Personas_Id",
                table: "Clientes",
                column: "Id",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Personas_Id",
                table: "Empleados",
                column: "Id",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Clientes_Id_cliente",
                table: "Factura",
                column: "Id_cliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Vehiculo_VehiculoId",
                table: "Factura",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Clientes_Id_cliente",
                table: "Vehiculo",
                column: "Id_cliente",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Clientes_Id_cliente",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Empleados_Id_empleado",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Personas_Id",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Personas_Id",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Clientes_Id_cliente",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Vehiculo_VehiculoId",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Clientes_Id_cliente",
                table: "Vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_Factura_VehiculoId",
                table: "Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Factura");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persona");

            migrationBuilder.RenameTable(
                name: "Empleados",
                newName: "Empleado");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.AlterColumn<long>(
                name: "Id_cliente",
                table: "Vehiculo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Puesto",
                table: "Empleado",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "Id_Empleado",
                table: "Empleado",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Cliente",
                table: "Cliente",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Cliente_Id_cliente",
                table: "Cita",
                column: "Id_cliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Empleado_Id_empleado",
                table: "Cita",
                column: "Id_empleado",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Persona_Id",
                table: "Cliente",
                column: "Id",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Persona_Id",
                table: "Empleado",
                column: "Id",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Cliente_Id_cliente",
                table: "Factura",
                column: "Id_cliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Cliente_Id_cliente",
                table: "Vehiculo",
                column: "Id_cliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
