using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fechas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    Mes = table.Column<int>(type: "integer", nullable: false),
                    Año = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fechas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Pais = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Horas = table.Column<int>(type: "integer", nullable: false),
                    Minutos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido1 = table.Column<string>(type: "text", nullable: true),
                    Apellido2 = table.Column<string>(type: "text", nullable: true),
                    DNI = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Id_Cliente = table.Column<long>(type: "bigint", nullable: true),
                    Cliente_Id_Persona = table.Column<long>(type: "bigint", nullable: true),
                    Cliente_PersonaId = table.Column<long>(type: "bigint", nullable: true),
                    Id_Empleado = table.Column<long>(type: "bigint", nullable: true),
                    Id_Persona = table.Column<long>(type: "bigint", nullable: true),
                    PersonaId = table.Column<long>(type: "bigint", nullable: true),
                    Sueldo = table.Column<int>(type: "integer", nullable: true),
                    Puesto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_Cliente_PersonaId",
                        column: x => x.Cliente_PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    CIF = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_grupo = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Año_fundacion = table.Column<int>(type: "integer", nullable: false),
                    Pais = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabricantes_Grupos_Id_grupo",
                        column: x => x.Id_grupo,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_fabricante = table.Column<long>(type: "bigint", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: true),
                    Motorizacion = table.Column<string>(type: "text", nullable: true),
                    Motor = table.Column<string>(type: "text", nullable: true),
                    Matricula = table.Column<string>(type: "text", nullable: true),
                    Fecha_matriculacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Id_cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Fabricantes_Id_fabricante",
                        column: x => x.Id_fabricante,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Persona_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_fecha = table.Column<long>(type: "bigint", nullable: false),
                    Id_hora = table.Column<long>(type: "bigint", nullable: false),
                    Id_vehiculo = table.Column<long>(type: "bigint", nullable: false),
                    Id_empleado = table.Column<long>(type: "bigint", nullable: false),
                    Id_cliente = table.Column<long>(type: "bigint", nullable: false),
                    Id_factura = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Fechas_Id_fecha",
                        column: x => x.Id_fecha,
                        principalTable: "Fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Horas_Id_hora",
                        column: x => x.Id_hora,
                        principalTable: "Horas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Persona_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Persona_Id_empleado",
                        column: x => x.Id_empleado,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Vehiculos_Id_vehiculo",
                        column: x => x.Id_vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_cliente = table.Column<long>(type: "bigint", nullable: false),
                    Id_cita = table.Column<long>(type: "bigint", nullable: false),
                    Precio = table.Column<int>(type: "integer", nullable: false),
                    Descuento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Citas_Id_cita",
                        column: x => x.Id_cita,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Persona_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    Id_categoria = table.Column<long>(type: "bigint", nullable: false),
                    CitaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piezas_Categorias_Id_categoria",
                        column: x => x.Id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Piezas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<int>(type: "integer", nullable: false),
                    Duracion = table.Column<decimal>(type: "numeric", nullable: false),
                    CitaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Metodo_Pago = table.Column<string>(type: "text", nullable: false),
                    Importe = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Facturas_Id",
                        column: x => x.Id,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitaPieza",
                columns: table => new
                {
                    Id_cita = table.Column<long>(type: "bigint", nullable: false),
                    Id_pieza = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaPieza", x => new { x.Id_cita, x.Id_pieza });
                    table.ForeignKey(
                        name: "FK_CitaPieza_Citas_Id_cita",
                        column: x => x.Id_cita,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitaPieza_Piezas_Id_pieza",
                        column: x => x.Id_pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaPieza",
                columns: table => new
                {
                    Id_factura = table.Column<long>(type: "bigint", nullable: false),
                    Id_pieza = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaPieza", x => new { x.Id_factura, x.Id_pieza });
                    table.ForeignKey(
                        name: "FK_FacturaPieza_Facturas_Id_factura",
                        column: x => x.Id_factura,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaPieza_Piezas_Id_pieza",
                        column: x => x.Id_pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiezaProveedor",
                columns: table => new
                {
                    Id_pieza = table.Column<long>(type: "bigint", nullable: false),
                    Id_proveedor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiezaProveedor", x => new { x.Id_pieza, x.Id_proveedor });
                    table.ForeignKey(
                        name: "FK_PiezaProveedor_Piezas_Id_pieza",
                        column: x => x.Id_pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiezaProveedor_Proveedores_Id_proveedor",
                        column: x => x.Id_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitaServicio",
                columns: table => new
                {
                    Id_cita = table.Column<long>(type: "bigint", nullable: false),
                    Id_servicio = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaServicio", x => new { x.Id_cita, x.Id_servicio });
                    table.ForeignKey(
                        name: "FK_CitaServicio_Citas_Id_cita",
                        column: x => x.Id_cita,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitaServicio_Servicios_Id_servicio",
                        column: x => x.Id_servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaServicio",
                columns: table => new
                {
                    Id_factura = table.Column<long>(type: "bigint", nullable: false),
                    Id_servicio = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaServicio", x => new { x.Id_factura, x.Id_servicio });
                    table.ForeignKey(
                        name: "FK_FacturaServicio_Facturas_Id_factura",
                        column: x => x.Id_factura,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaServicio_Servicios_Id_servicio",
                        column: x => x.Id_servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitaPieza_Id_pieza",
                table: "CitaPieza",
                column: "Id_pieza");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_cliente",
                table: "Citas",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_empleado",
                table: "Citas",
                column: "Id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_fecha",
                table: "Citas",
                column: "Id_fecha");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_hora",
                table: "Citas",
                column: "Id_hora",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_vehiculo",
                table: "Citas",
                column: "Id_vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_CitaServicio_Id_servicio",
                table: "CitaServicio",
                column: "Id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricantes_Id_grupo",
                table: "Fabricantes",
                column: "Id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaPieza_Id_pieza",
                table: "FacturaPieza",
                column: "Id_pieza");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Id_cita",
                table: "Facturas",
                column: "Id_cita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Id_cliente",
                table: "Facturas",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaServicio_Id_servicio",
                table: "FacturaServicio",
                column: "Id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Cliente_PersonaId",
                table: "Persona",
                column: "Cliente_PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_PersonaId",
                table: "Persona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaProveedor_Id_proveedor",
                table: "PiezaProveedor",
                column: "Id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_CitaId",
                table: "Piezas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_Id_categoria",
                table: "Piezas",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_CitaId",
                table: "Servicios",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Id_cliente",
                table: "Vehiculos",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Id_fabricante",
                table: "Vehiculos",
                column: "Id_fabricante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitaPieza");

            migrationBuilder.DropTable(
                name: "CitaServicio");

            migrationBuilder.DropTable(
                name: "FacturaPieza");

            migrationBuilder.DropTable(
                name: "FacturaServicio");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PiezaProveedor");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Fechas");

            migrationBuilder.DropTable(
                name: "Horas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Grupos");
        }
    }
}
