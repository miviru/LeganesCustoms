using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonaSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Persona_Id_cliente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Persona_Id_empleado",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Persona_Id_cliente",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Persona_Cliente_PersonaId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Persona_PersonaId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Persona_Id_cliente",
                table: "Vehiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_Cliente_PersonaId",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_PersonaId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Cliente_Id_Persona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Cliente_PersonaId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Id_Persona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Persona");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehiculos",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Grupos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Fabricantes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido2",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido1",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Personas_Id_cliente",
                table: "Citas",
                column: "Id_cliente",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Personas_Id_empleado",
                table: "Citas",
                column: "Id_empleado",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Personas_Id_cliente",
                table: "Facturas",
                column: "Id_cliente",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_Id_cliente",
                table: "Vehiculos",
                column: "Id_cliente",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Personas_Id_cliente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Personas_Id_empleado",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Personas_Id_cliente",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_Id_cliente",
                table: "Vehiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persona");

            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "Vehiculos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Grupos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Fabricantes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Persona",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Persona",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persona",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Persona",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido2",
                table: "Persona",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido1",
                table: "Persona",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "Cliente_Id_Persona",
                table: "Persona",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Cliente_PersonaId",
                table: "Persona",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id_Persona",
                table: "Persona",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PersonaId",
                table: "Persona",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Cliente_PersonaId",
                table: "Persona",
                column: "Cliente_PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_PersonaId",
                table: "Persona",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Persona_Id_cliente",
                table: "Citas",
                column: "Id_cliente",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Persona_Id_empleado",
                table: "Citas",
                column: "Id_empleado",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Persona_Id_cliente",
                table: "Facturas",
                column: "Id_cliente",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Persona_Cliente_PersonaId",
                table: "Persona",
                column: "Cliente_PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Persona_PersonaId",
                table: "Persona",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Persona_Id_cliente",
                table: "Vehiculos",
                column: "Id_cliente",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
