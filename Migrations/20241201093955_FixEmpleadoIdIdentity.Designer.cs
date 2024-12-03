﻿// <auto-generated />
using System;
using LeganesCustomsBlazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241201093955_FixEmpleadoIdIdentity")]
    partial class FixEmpleadoIdIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Cita", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("Id_cliente")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_empleado")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_factura")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_fecha")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_hora")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_vehiculo")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id_cliente");

                    b.HasIndex("Id_empleado");

                    b.HasIndex("Id_fecha");

                    b.HasIndex("Id_hora")
                        .IsUnique();

                    b.HasIndex("Id_vehiculo");

                    b.ToTable("Cita", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.CitaPieza", b =>
                {
                    b.Property<long>("Id_cita")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_pieza")
                        .HasColumnType("bigint");

                    b.HasKey("Id_cita", "Id_pieza");

                    b.HasIndex("Id_pieza");

                    b.ToTable("CitaPieza");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.CitaServicio", b =>
                {
                    b.Property<long>("Id_cita")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_servicio")
                        .HasColumnType("bigint");

                    b.HasKey("Id_cita", "Id_servicio");

                    b.HasIndex("Id_servicio");

                    b.ToTable("CitaServicio");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Fabricante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Año_fundacion")
                        .HasColumnType("integer");

                    b.Property<long>("Id_grupo")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Pais")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id_grupo");

                    b.ToTable("Fabricante", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Factura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Descuento")
                        .HasColumnType("numeric");

                    b.Property<long>("Id_cita")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_cliente")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<long>("VehiculoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id_cita")
                        .IsUnique();

                    b.HasIndex("Id_cliente");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.FacturaPieza", b =>
                {
                    b.Property<long>("Id_factura")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_pieza")
                        .HasColumnType("bigint");

                    b.HasKey("Id_factura", "Id_pieza");

                    b.HasIndex("Id_pieza");

                    b.ToTable("FacturaPieza");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.FacturaServicio", b =>
                {
                    b.Property<long>("Id_factura")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_servicio")
                        .HasColumnType("bigint");

                    b.HasKey("Id_factura", "Id_servicio");

                    b.HasIndex("Id_servicio");

                    b.ToTable("FacturaServicio");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Fecha", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Año")
                        .HasColumnType("integer");

                    b.Property<int>("Dia")
                        .HasColumnType("integer");

                    b.Property<int>("Mes")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Fecha", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Grupo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Grupo", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Hora", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Horas")
                        .HasColumnType("integer");

                    b.Property<int>("Minutos")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Hora", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Pago", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Importe")
                        .HasColumnType("numeric");

                    b.Property<string>("Metodo_Pago")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pago", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Persona", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persona", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Pieza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<long?>("CitaId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_categoria")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.HasIndex("Id_categoria");

                    b.ToTable("Pieza", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.PiezaProveedor", b =>
                {
                    b.Property<long>("Id_pieza")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_proveedor")
                        .HasColumnType("bigint");

                    b.HasKey("Id_pieza", "Id_proveedor");

                    b.HasIndex("Id_proveedor");

                    b.ToTable("PiezaProveedor");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Proveedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CIF")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Servicio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CitaId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Duracion")
                        .HasColumnType("numeric");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<int>("Precio")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.ToTable("Servicio", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Vehiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha_matriculacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("text");

                    b.Property<long>("Id_cliente")
                        .HasColumnType("bigint");

                    b.Property<long>("Id_fabricante")
                        .HasColumnType("bigint");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Motor")
                        .HasColumnType("text");

                    b.Property<string>("Motorizacion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id_cliente");

                    b.HasIndex("Id_fabricante");

                    b.ToTable("Vehiculo", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Cliente", b =>
                {
                    b.HasBaseType("LeganesCustomsBlazor.Models.Persona");

                    b.Property<long>("Id_Cliente")
                        .HasColumnType("bigint");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Empleado", b =>
                {
                    b.HasBaseType("LeganesCustomsBlazor.Models.Persona");

                    b.Property<long>("Id_Empleado")
                        .HasColumnType("bigint");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sueldo")
                        .HasColumnType("integer");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Cita", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cliente", "Cliente")
                        .WithMany("Citas")
                        .HasForeignKey("Id_cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Empleado", "Empleado")
                        .WithMany("Citas")
                        .HasForeignKey("Id_empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Fecha", "Fecha")
                        .WithMany("Citas")
                        .HasForeignKey("Id_fecha")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Hora", "Hora")
                        .WithOne("Cita")
                        .HasForeignKey("LeganesCustomsBlazor.Models.Cita", "Id_hora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Vehiculo", "Vehiculo")
                        .WithMany("Citas")
                        .HasForeignKey("Id_vehiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("Fecha");

                    b.Navigation("Hora");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.CitaPieza", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cita", "Cita")
                        .WithMany("CitaPiezas")
                        .HasForeignKey("Id_cita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Pieza", "Pieza")
                        .WithMany("CitaPiezas")
                        .HasForeignKey("Id_pieza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Pieza");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.CitaServicio", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cita", "Cita")
                        .WithMany("CitaServicios")
                        .HasForeignKey("Id_cita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Servicio", "Servicio")
                        .WithMany("CitaServicios")
                        .HasForeignKey("Id_servicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Fabricante", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Grupo", "Grupo")
                        .WithMany("Fabricantes")
                        .HasForeignKey("Id_grupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Factura", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cita", "Cita")
                        .WithOne("Factura")
                        .HasForeignKey("LeganesCustomsBlazor.Models.Factura", "Id_cita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("Id_cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Vehiculo", "Vehiculo")
                        .WithMany("Facturas")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Cliente");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.FacturaPieza", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Factura", "Factura")
                        .WithMany("FacturaPiezas")
                        .HasForeignKey("Id_factura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Pieza", "Pieza")
                        .WithMany("FacturaPiezas")
                        .HasForeignKey("Id_pieza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Pieza");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.FacturaServicio", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Factura", "Factura")
                        .WithMany("FacturaServicios")
                        .HasForeignKey("Id_factura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Servicio", "Servicio")
                        .WithMany("FacturaServicios")
                        .HasForeignKey("Id_servicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Pago", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Factura", "Factura")
                        .WithOne("Pago")
                        .HasForeignKey("LeganesCustomsBlazor.Models.Pago", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Pieza", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cita", null)
                        .WithMany("Piezas")
                        .HasForeignKey("CitaId");

                    b.HasOne("LeganesCustomsBlazor.Models.Categoria", "Categoria")
                        .WithMany("Piezas")
                        .HasForeignKey("Id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.PiezaProveedor", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Pieza", "Pieza")
                        .WithMany("PiezaProveedores")
                        .HasForeignKey("Id_pieza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Proveedor", "Proveedor")
                        .WithMany("PiezaProveedores")
                        .HasForeignKey("Id_proveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pieza");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Servicio", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cita", null)
                        .WithMany("Servicios")
                        .HasForeignKey("CitaId");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Vehiculo", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Cliente", "Cliente")
                        .WithMany("Vehiculos")
                        .HasForeignKey("Id_cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeganesCustomsBlazor.Models.Fabricante", "Fabricante")
                        .WithMany("Vehiculos")
                        .HasForeignKey("Id_fabricante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Cliente", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Persona", null)
                        .WithOne()
                        .HasForeignKey("LeganesCustomsBlazor.Models.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Empleado", b =>
                {
                    b.HasOne("LeganesCustomsBlazor.Models.Persona", null)
                        .WithOne()
                        .HasForeignKey("LeganesCustomsBlazor.Models.Empleado", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Categoria", b =>
                {
                    b.Navigation("Piezas");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Cita", b =>
                {
                    b.Navigation("CitaPiezas");

                    b.Navigation("CitaServicios");

                    b.Navigation("Factura");

                    b.Navigation("Piezas");

                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Fabricante", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Factura", b =>
                {
                    b.Navigation("FacturaPiezas");

                    b.Navigation("FacturaServicios");

                    b.Navigation("Pago");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Fecha", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Grupo", b =>
                {
                    b.Navigation("Fabricantes");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Hora", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Pieza", b =>
                {
                    b.Navigation("CitaPiezas");

                    b.Navigation("FacturaPiezas");

                    b.Navigation("PiezaProveedores");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Proveedor", b =>
                {
                    b.Navigation("PiezaProveedores");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Servicio", b =>
                {
                    b.Navigation("CitaServicios");

                    b.Navigation("FacturaServicios");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Vehiculo", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Cliente", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Facturas");

                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("LeganesCustomsBlazor.Models.Empleado", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
