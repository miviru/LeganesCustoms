using Microsoft.EntityFrameworkCore;

namespace LeganesCustomsBlazor.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Aquí defines tus DbSets, que representan tus tablas en la base de datos.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Hora> Horas { get; set; }
        public DbSet<Fecha> Fechas { get; set; }
        public DbSet<Factura> Facturas { get; set; } 
        public DbSet<Pago> Pagos { get; set; } 
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; } 
        public DbSet<Proveedor> Proveedores { get; set; } 
        public DbSet<Pieza> Piezas { get; set; } 
        public DbSet<Categoria> Categorias { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación 1:1 entre Cita y Factura
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Factura) // Cita tiene una Factura
                .WithOne(f => f.Cita) // Factura tiene una Cita
                .HasForeignKey<Factura>(f => f.Id_cita); // Establecer CitaId como la clave foránea en Factura

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Vehiculos) // Un Cliente puede tener muchos Vehículos
                .WithOne(v => v.Cliente); // Un Vehículo pertenece a un Cliente

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Cliente) // Cita tiene un Cliente
                .WithMany(); // Un Cliente puede tener muchas Citas

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Empleado) // Cita tiene un Empleado
                .WithMany(); // Un Empleado puede tener muchas Citas

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Vehiculo) // Cita tiene un Vehículo
                .WithMany(); // Un Vehículo puede tener muchas Citas

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Hora) // Cita tiene una Hora
                .WithMany(); // Una Hora puede estar asociada a muchas Citas

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Fecha) // Cita tiene una Fecha
                .WithMany(); // Una Fecha puede estar asociada a muchas Citas
        }
    }
}
