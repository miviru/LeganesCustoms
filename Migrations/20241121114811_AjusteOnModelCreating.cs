using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AjusteOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitaPieza_Citas_Id_cita",
                table: "CitaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaPieza_Piezas_Id_pieza",
                table: "CitaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Fechas_Id_fecha",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Horas_Id_hora",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Personas_Id_cliente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Personas_Id_empleado",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Vehiculos_Id_vehiculo",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaServicio_Citas_Id_cita",
                table: "CitaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaServicio_Servicios_Id_servicio",
                table: "CitaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Fabricantes_Grupos_Id_grupo",
                table: "Fabricantes");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaPieza_Facturas_Id_factura",
                table: "FacturaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaPieza_Piezas_Id_pieza",
                table: "FacturaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Citas_Id_cita",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Personas_Id_cliente",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaServicio_Facturas_Id_factura",
                table: "FacturaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaServicio_Servicios_Id_servicio",
                table: "FacturaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Facturas_Id",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PiezaProveedor_Piezas_Id_pieza",
                table: "PiezaProveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_PiezaProveedor_Proveedores_Id_proveedor",
                table: "PiezaProveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Piezas_Categorias_Id_categoria",
                table: "Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Piezas_Citas_CitaId",
                table: "Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Citas_CitaId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Fabricantes_Id_fabricante",
                table: "Vehiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_Id_cliente",
                table: "Vehiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicios",
                table: "Servicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Piezas",
                table: "Piezas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagos",
                table: "Pagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horas",
                table: "Horas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupos",
                table: "Grupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fechas",
                table: "Fechas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fabricantes",
                table: "Fabricantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Citas",
                table: "Citas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Id_Cliente",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Id_Empleado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Puesto",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Vehiculos",
                newName: "Vehiculo");

            migrationBuilder.RenameTable(
                name: "Servicios",
                newName: "Servicio");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Piezas",
                newName: "Pieza");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persona");

            migrationBuilder.RenameTable(
                name: "Pagos",
                newName: "Pago");

            migrationBuilder.RenameTable(
                name: "Horas",
                newName: "Hora");

            migrationBuilder.RenameTable(
                name: "Grupos",
                newName: "Grupo");

            migrationBuilder.RenameTable(
                name: "Fechas",
                newName: "Fecha");

            migrationBuilder.RenameTable(
                name: "Facturas",
                newName: "Factura");

            migrationBuilder.RenameTable(
                name: "Fabricantes",
                newName: "Fabricante");

            migrationBuilder.RenameTable(
                name: "Citas",
                newName: "Cita");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculos_Id_fabricante",
                table: "Vehiculo",
                newName: "IX_Vehiculo_Id_fabricante");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculos_Id_cliente",
                table: "Vehiculo",
                newName: "IX_Vehiculo_Id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_CitaId",
                table: "Servicio",
                newName: "IX_Servicio_CitaId");

            migrationBuilder.RenameIndex(
                name: "IX_Piezas_Id_categoria",
                table: "Pieza",
                newName: "IX_Pieza_Id_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Piezas_CitaId",
                table: "Pieza",
                newName: "IX_Pieza_CitaId");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_Id_cliente",
                table: "Factura",
                newName: "IX_Factura_Id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_Id_cita",
                table: "Factura",
                newName: "IX_Factura_Id_cita");

            migrationBuilder.RenameIndex(
                name: "IX_Fabricantes_Id_grupo",
                table: "Fabricante",
                newName: "IX_Fabricante_Id_grupo");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_Id_vehiculo",
                table: "Cita",
                newName: "IX_Cita_Id_vehiculo");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_Id_hora",
                table: "Cita",
                newName: "IX_Cita_Id_hora");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_Id_fecha",
                table: "Cita",
                newName: "IX_Cita_Id_fecha");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_Id_empleado",
                table: "Cita",
                newName: "IX_Cita_Id_empleado");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_Id_cliente",
                table: "Cita",
                newName: "IX_Cita_Id_cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicio",
                table: "Servicio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pieza",
                table: "Pieza",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pago",
                table: "Pago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hora",
                table: "Hora",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fecha",
                table: "Fecha",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura",
                table: "Factura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fabricante",
                table: "Fabricante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cita",
                table: "Cita",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Id_Cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Id_Empleado = table.Column<long>(type: "bigint", nullable: false),
                    Sueldo = table.Column<int>(type: "integer", nullable: false),
                    Puesto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "FK_Cita_Fecha_Id_fecha",
                table: "Cita",
                column: "Id_fecha",
                principalTable: "Fecha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Hora_Id_hora",
                table: "Cita",
                column: "Id_hora",
                principalTable: "Hora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Vehiculo_Id_vehiculo",
                table: "Cita",
                column: "Id_vehiculo",
                principalTable: "Vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaPieza_Cita_Id_cita",
                table: "CitaPieza",
                column: "Id_cita",
                principalTable: "Cita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaPieza_Pieza_Id_pieza",
                table: "CitaPieza",
                column: "Id_pieza",
                principalTable: "Pieza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaServicio_Cita_Id_cita",
                table: "CitaServicio",
                column: "Id_cita",
                principalTable: "Cita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaServicio_Servicio_Id_servicio",
                table: "CitaServicio",
                column: "Id_servicio",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fabricante_Grupo_Id_grupo",
                table: "Fabricante",
                column: "Id_grupo",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Cita_Id_cita",
                table: "Factura",
                column: "Id_cita",
                principalTable: "Cita",
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
                name: "FK_FacturaPieza_Factura_Id_factura",
                table: "FacturaPieza",
                column: "Id_factura",
                principalTable: "Factura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaPieza_Pieza_Id_pieza",
                table: "FacturaPieza",
                column: "Id_pieza",
                principalTable: "Pieza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaServicio_Factura_Id_factura",
                table: "FacturaServicio",
                column: "Id_factura",
                principalTable: "Factura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaServicio_Servicio_Id_servicio",
                table: "FacturaServicio",
                column: "Id_servicio",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Factura_Id",
                table: "Pago",
                column: "Id",
                principalTable: "Factura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieza_Categoria_Id_categoria",
                table: "Pieza",
                column: "Id_categoria",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieza_Cita_CitaId",
                table: "Pieza",
                column: "CitaId",
                principalTable: "Cita",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PiezaProveedor_Pieza_Id_pieza",
                table: "PiezaProveedor",
                column: "Id_pieza",
                principalTable: "Pieza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiezaProveedor_Proveedor_Id_proveedor",
                table: "PiezaProveedor",
                column: "Id_proveedor",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_Cita_CitaId",
                table: "Servicio",
                column: "CitaId",
                principalTable: "Cita",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Cliente_Id_cliente",
                table: "Vehiculo",
                column: "Id_cliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Fabricante_Id_fabricante",
                table: "Vehiculo",
                column: "Id_fabricante",
                principalTable: "Fabricante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Cliente_Id_cliente",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Empleado_Id_empleado",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Fecha_Id_fecha",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Hora_Id_hora",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Vehiculo_Id_vehiculo",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaPieza_Cita_Id_cita",
                table: "CitaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaPieza_Pieza_Id_pieza",
                table: "CitaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaServicio_Cita_Id_cita",
                table: "CitaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaServicio_Servicio_Id_servicio",
                table: "CitaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Fabricante_Grupo_Id_grupo",
                table: "Fabricante");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cita_Id_cita",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cliente_Id_cliente",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaPieza_Factura_Id_factura",
                table: "FacturaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaPieza_Pieza_Id_pieza",
                table: "FacturaPieza");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaServicio_Factura_Id_factura",
                table: "FacturaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaServicio_Servicio_Id_servicio",
                table: "FacturaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Factura_Id",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieza_Categoria_Id_categoria",
                table: "Pieza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieza_Cita_CitaId",
                table: "Pieza");

            migrationBuilder.DropForeignKey(
                name: "FK_PiezaProveedor_Pieza_Id_pieza",
                table: "PiezaProveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_PiezaProveedor_Proveedor_Id_proveedor",
                table: "PiezaProveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_Cita_CitaId",
                table: "Servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Cliente_Id_cliente",
                table: "Vehiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Fabricante_Id_fabricante",
                table: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicio",
                table: "Servicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pieza",
                table: "Pieza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pago",
                table: "Pago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hora",
                table: "Hora");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fecha",
                table: "Fecha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura",
                table: "Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fabricante",
                table: "Fabricante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cita",
                table: "Cita");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Vehiculo",
                newName: "Vehiculos");

            migrationBuilder.RenameTable(
                name: "Servicio",
                newName: "Servicios");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Pieza",
                newName: "Piezas");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Personas");

            migrationBuilder.RenameTable(
                name: "Pago",
                newName: "Pagos");

            migrationBuilder.RenameTable(
                name: "Hora",
                newName: "Horas");

            migrationBuilder.RenameTable(
                name: "Grupo",
                newName: "Grupos");

            migrationBuilder.RenameTable(
                name: "Fecha",
                newName: "Fechas");

            migrationBuilder.RenameTable(
                name: "Factura",
                newName: "Facturas");

            migrationBuilder.RenameTable(
                name: "Fabricante",
                newName: "Fabricantes");

            migrationBuilder.RenameTable(
                name: "Cita",
                newName: "Citas");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculo_Id_fabricante",
                table: "Vehiculos",
                newName: "IX_Vehiculos_Id_fabricante");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculo_Id_cliente",
                table: "Vehiculos",
                newName: "IX_Vehiculos_Id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Servicio_CitaId",
                table: "Servicios",
                newName: "IX_Servicios_CitaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieza_Id_categoria",
                table: "Piezas",
                newName: "IX_Piezas_Id_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Pieza_CitaId",
                table: "Piezas",
                newName: "IX_Piezas_CitaId");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_Id_cliente",
                table: "Facturas",
                newName: "IX_Facturas_Id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_Id_cita",
                table: "Facturas",
                newName: "IX_Facturas_Id_cita");

            migrationBuilder.RenameIndex(
                name: "IX_Fabricante_Id_grupo",
                table: "Fabricantes",
                newName: "IX_Fabricantes_Id_grupo");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_Id_vehiculo",
                table: "Citas",
                newName: "IX_Citas_Id_vehiculo");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_Id_hora",
                table: "Citas",
                newName: "IX_Citas_Id_hora");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_Id_fecha",
                table: "Citas",
                newName: "IX_Citas_Id_fecha");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_Id_empleado",
                table: "Citas",
                newName: "IX_Citas_Id_empleado");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_Id_cliente",
                table: "Citas",
                newName: "IX_Citas_Id_cliente");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Id_Cliente",
                table: "Personas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id_Empleado",
                table: "Personas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Puesto",
                table: "Personas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sueldo",
                table: "Personas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicios",
                table: "Servicios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Piezas",
                table: "Piezas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagos",
                table: "Pagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horas",
                table: "Horas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupos",
                table: "Grupos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fechas",
                table: "Fechas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fabricantes",
                table: "Fabricantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Citas",
                table: "Citas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitaPieza_Citas_Id_cita",
                table: "CitaPieza",
                column: "Id_cita",
                principalTable: "Citas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaPieza_Piezas_Id_pieza",
                table: "CitaPieza",
                column: "Id_pieza",
                principalTable: "Piezas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Fechas_Id_fecha",
                table: "Citas",
                column: "Id_fecha",
                principalTable: "Fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Horas_Id_hora",
                table: "Citas",
                column: "Id_hora",
                principalTable: "Horas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Citas_Vehiculos_Id_vehiculo",
                table: "Citas",
                column: "Id_vehiculo",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaServicio_Citas_Id_cita",
                table: "CitaServicio",
                column: "Id_cita",
                principalTable: "Citas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaServicio_Servicios_Id_servicio",
                table: "CitaServicio",
                column: "Id_servicio",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fabricantes_Grupos_Id_grupo",
                table: "Fabricantes",
                column: "Id_grupo",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaPieza_Facturas_Id_factura",
                table: "FacturaPieza",
                column: "Id_factura",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaPieza_Piezas_Id_pieza",
                table: "FacturaPieza",
                column: "Id_pieza",
                principalTable: "Piezas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Citas_Id_cita",
                table: "Facturas",
                column: "Id_cita",
                principalTable: "Citas",
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
                name: "FK_FacturaServicio_Facturas_Id_factura",
                table: "FacturaServicio",
                column: "Id_factura",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaServicio_Servicios_Id_servicio",
                table: "FacturaServicio",
                column: "Id_servicio",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Facturas_Id",
                table: "Pagos",
                column: "Id",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiezaProveedor_Piezas_Id_pieza",
                table: "PiezaProveedor",
                column: "Id_pieza",
                principalTable: "Piezas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiezaProveedor_Proveedores_Id_proveedor",
                table: "PiezaProveedor",
                column: "Id_proveedor",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Piezas_Categorias_Id_categoria",
                table: "Piezas",
                column: "Id_categoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Piezas_Citas_CitaId",
                table: "Piezas",
                column: "CitaId",
                principalTable: "Citas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Citas_CitaId",
                table: "Servicios",
                column: "CitaId",
                principalTable: "Citas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Fabricantes_Id_fabricante",
                table: "Vehiculos",
                column: "Id_fabricante",
                principalTable: "Fabricantes",
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
    }
}
