using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Models;
 

namespace LeganesCustomsBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets (tablas)
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public DbSet<Cita> Citas { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<Hora> Horas { get; set; } = null!;
        public DbSet<Fecha> Fechas { get; set; } = null!;
        public DbSet<Factura> Facturas { get; set; } = null!;
        public DbSet<Pago> Pagos { get; set; } = null!;
        public DbSet<Servicio> Servicios { get; set; } = null!;
        public DbSet<Fabricante> Fabricantes { get; set; } = null!;
        public DbSet<Proveedor> Proveedores { get; set; } = null!;
        public DbSet<Pieza> Piezas { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Grupo> Grupos { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura nombres explícitos de tablas en singular
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo");
            modelBuilder.Entity<Cita>().ToTable("Cita");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Hora>().ToTable("Hora");
            modelBuilder.Entity<Fecha>().ToTable("Fecha");
            modelBuilder.Entity<Factura>().ToTable("Factura");
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<Servicio>().ToTable("Servicio");
            modelBuilder.Entity<Fabricante>().ToTable("Fabricante");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedor");
            modelBuilder.Entity<Pieza>().ToTable("Pieza");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Grupo>().ToTable("Grupo");

            // Llama al método base
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Piezas)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.Id_categoria);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Factura)
                .WithOne(f => f.Cita)
                .HasForeignKey<Factura>(f => f.Id_cita);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Vehiculo)
                .WithMany(v => v.Citas)
                .HasForeignKey(c => c.Id_vehiculo);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Empleado)
                .WithMany(e => e.Citas)
                .HasForeignKey(c => c.Id_empleado);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Cliente)
                .WithMany(cli => cli.Citas)
                .HasForeignKey(c => c.Id_cliente);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Fecha) // Una Cita tiene una Fecha
                .WithMany(f => f.Citas) // Una Fecha tiene muchas Citas
                .HasForeignKey(c => c.Id_fecha); // Clave foránea en Cita

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Hora) // Una Cita tiene una Hora
                .WithOne(h => h.Cita) // Una Hora está asociada a una única Cita
                .HasForeignKey<Cita>(c => c.Id_hora); // Clave foránea en Cita

            modelBuilder.Entity<CitaPieza>()
                .HasKey(cp => new { cp.Id_cita, cp.Id_pieza }); // Clave compuesta

            modelBuilder.Entity<CitaPieza>()
                .HasOne(cp => cp.Cita)
                .WithMany(c => c.CitaPiezas)
                .HasForeignKey(cp => cp.Id_cita);

            modelBuilder.Entity<CitaPieza>()
                .HasOne(cp => cp.Pieza)
                .WithMany(p => p.CitaPiezas)
                .HasForeignKey(cp => cp.Id_pieza);

            modelBuilder.Entity<CitaServicio>()
                .HasKey(cs => new { cs.Id_cita, cs.Id_servicio }); // Clave compuesta

            modelBuilder.Entity<CitaServicio>()
                .HasOne(cs => cs.Cita)
                .WithMany(c => c.CitaServicios)
                .HasForeignKey(cs => cs.Id_cita);

            modelBuilder.Entity<CitaServicio>()
                .HasOne(cs => cs.Servicio)
                .WithMany(s => s.CitaServicios)
                .HasForeignKey(cs => cs.Id_servicio);


            modelBuilder.Entity<Fabricante>()
                .HasMany(f => f.Vehiculos)
                .WithOne(v => v.Fabricante)
                .HasForeignKey(v => v.Id_fabricante);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente) // Una Factura tiene un Cliente
                .WithMany(c => c.Facturas) // Un Cliente tiene muchas Facturas
                .HasForeignKey(f => f.Id_cliente); // Clave foránea en Factura


            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Pago) // Una Factura tiene un Pago
                .WithOne(p => p.Factura) // Un Pago pertenece a una Factura
                .HasForeignKey<Pago>(p => p.Id); // Clave foránea y clave primaria compartida en Pago

            // Relación N:M entre Factura y Servicio
            modelBuilder.Entity<FacturaServicio>()
                .HasKey(fs => new { fs.Id_factura, fs.Id_servicio }); // Clave compuesta

            modelBuilder.Entity<FacturaServicio>()
                .HasOne(fs => fs.Factura)
                .WithMany(f => f.FacturaServicios)
                .HasForeignKey(fs => fs.Id_factura);

            modelBuilder.Entity<FacturaServicio>()
                .HasOne(fs => fs.Servicio)
                .WithMany(s => s.FacturaServicios)
                .HasForeignKey(fs => fs.Id_servicio);

            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.Fabricantes)
                .WithOne(f => f.Grupo)
                .HasForeignKey(f => f.Id_grupo);

            modelBuilder.Entity<FacturaPieza>()
                .HasKey(fp => new { fp.Id_factura, fp.Id_pieza }); // Clave compuesta

            modelBuilder.Entity<FacturaPieza>()
                .HasOne(fp => fp.Factura)
                .WithMany(f => f.FacturaPiezas)
                .HasForeignKey(fp => fp.Id_factura);

            modelBuilder.Entity<FacturaPieza>()
                .HasOne(fp => fp.Pieza)
                .WithMany(p => p.FacturaPiezas)
                .HasForeignKey(fp => fp.Id_pieza);

            modelBuilder.Entity<PiezaProveedor>()
                .HasKey(pp => new { pp.Id_pieza, pp.Id_proveedor }); // Clave compuesta

            modelBuilder.Entity<PiezaProveedor>()
                .HasOne(pp => pp.Pieza)
                .WithMany(p => p.PiezaProveedores)
                .HasForeignKey(pp => pp.Id_pieza);

            modelBuilder.Entity<PiezaProveedor>()
                .HasOne(pp => pp.Proveedor)
                .WithMany(p => p.PiezaProveedores)
                .HasForeignKey(pp => pp.Id_proveedor);

            modelBuilder.Entity<Cliente>()
                .HasMany(cli => cli.Vehiculos)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.Id_cliente);

            // Configuración de enums
            modelBuilder.Entity<Grupo>()
                .Property(g => g.Pais)
                .HasConversion<string>();

            modelBuilder.Entity<Pago>()
                .Property(p => p.Metodo_Pago)
                .HasConversion<string>();

            // Configurar relación 1:N entre Vehiculo y Factura
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Vehiculo) // Factura tiene un Vehículo
                .WithMany(v => v.Facturas) // Un Vehículo tiene muchas Facturas
                .HasForeignKey(f => f.VehiculoId) // Clave foránea en Factura
                .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
        
            // Configuración de la relación y propiedad VehiculoId
            modelBuilder.Entity<Factura>()
                .Property(f => f.VehiculoId)
                .IsRequired(); // Asegura que VehiculoId no pueda ser nulo

        }
    }
}
