using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LeganesCustomsBlazor.Data
{
    public static class DataInitializer
    {
        public static void SeedData(AppDbContext context)
        {
            // Inicializa fabricantes
            SeedFabricantes(context);

            // Inicializa clientes
            SeedClientes(context);

            // Inicializa empleados
            SeedEmpleados(context);

            // Inicializa vehículos
            SeedVehiculos(context);

            // Inicializa citas
            SeedCitas(context);

            // Inicializa facturas
            SeedFacturas(context);
        }

        private static void SeedFabricantes(AppDbContext context)
        {
            var fabricanteToyota = context.Fabricantes.FirstOrDefault(f => f.Nombre == "Toyota");
            if (fabricanteToyota == null)
            {
                fabricanteToyota = new Fabricante
                {
                    Nombre = "Toyota",
                    Grupo = new Grupo
                    {
                        Nombre = "Toyota Group",
                        Fabricantes = new List<Fabricante>()
                    },
                    Vehiculos = new List<Vehiculo>()
                };
                context.Fabricantes.Add(fabricanteToyota);
            }

            var fabricanteFord = context.Fabricantes.FirstOrDefault(f => f.Nombre == "Ford");
            if (fabricanteFord == null)
            {
                fabricanteFord = new Fabricante
                {
                    Nombre = "Ford",
                    Grupo = new Grupo
                    {
                        Nombre = "Ford Motor Company",
                        Fabricantes = new List<Fabricante>()
                    },
                    Vehiculos = new List<Vehiculo>()
                };
                context.Fabricantes.Add(fabricanteFord);
            }

            context.SaveChanges();
        }

        private static void SeedClientes(AppDbContext context)
        {
            var cliente = context.Personas.OfType<Cliente>().FirstOrDefault(c => c.Nombre == "Maikel");
            if (cliente == null)
            {
                cliente = new Cliente
                {
                    Nombre = "Maikel",
                    Apellido1 = "Delafont",
                    Apellido2 = "Escudero",
                    DNI = "12345678A",
                    Email = "maikel.dlf@example.com",
                    Telefono = "123456789",
                    Direccion = "Calle Ejemplo, 123",
                    Vehiculos = new List<Vehiculo>()
                };
                context.Personas.Add(cliente);
            }
            else
            {
                cliente.Apellido1 = "Delafont";
                cliente.Apellido2 = "Escudero";
                cliente.Email = "maikel.dlf@example.com";
                cliente.Telefono = "123456789";
                cliente.Direccion = "Calle Ejemplo, 123";
            }
            context.SaveChanges();
        }

        private static void SeedEmpleados(AppDbContext context)
        {
            var empleado = context.Personas.OfType<Empleado>().FirstOrDefault(e => e.Nombre == "Daniel");
            if (empleado == null)
            {
                empleado = new Empleado
                {
                    Nombre = "Daniel",
                    Apellido1 = "Raba",
                    Apellido2 = "Antolin",
                    DNI = "87654321B",
                    Email = "dani.rabita@example.com",
                    Telefono = "987654321",
                    Direccion = "Calle Mayor 123",
                    Sueldo = 3000,
                    Puesto = "Mecánico"
                };
                context.Personas.Add(empleado);
            }
            else
            {
                empleado.Apellido1 = "Raba";
                empleado.Apellido2 = "Antolin";
                empleado.Email = "dani.rabita@example.com";
                empleado.Telefono = "987654321";
            }
            context.SaveChanges();
        }

        private static void SeedVehiculos(AppDbContext context)
        {
            var cliente = context.Personas.OfType<Cliente>().FirstOrDefault(c => c.Nombre == "Maikel");
            var fabricanteToyota = context.Fabricantes.FirstOrDefault(f => f.Nombre == "Toyota");
            var fabricanteFord = context.Fabricantes.FirstOrDefault(f => f.Nombre == "Ford");

            if (fabricanteToyota == null)
            {
                fabricanteToyota = new Fabricante
                {
                    Nombre = "Toyota",
                    Grupo = new Grupo
                    {
                        Nombre = "Toyota Group",
                        Fabricantes = new List<Fabricante>()
                    },
                    Vehiculos = new List<Vehiculo>()
                };
                context.Fabricantes.Add(fabricanteToyota);
                context.SaveChanges();
            }

            if (fabricanteFord == null)
            {
                fabricanteFord = new Fabricante
                {
                    Nombre = "Ford",
                    Grupo = new Grupo
                    {
                        Nombre = "Ford Motor Company",
                        Fabricantes = new List<Fabricante>()
                    },
                    Vehiculos = new List<Vehiculo>()
                };
                context.Fabricantes.Add(fabricanteFord);
                context.SaveChanges();
            }

            if (cliente != null)
            {
                if (!context.Vehiculos.Any(v => v.Matricula == "1234ABC"))
                {
                    context.Vehiculos.Add(new Vehiculo
                    {
                        Matricula = "1234ABC",
                        Modelo = "Corolla",
                        Color = "Rojo",
                        FotoUrl = "/Corolla.png",
                        Cliente = cliente,
                        Fabricante = fabricanteToyota
                    });
                }

                if (!context.Vehiculos.Any(v => v.Matricula == "0000 MMM"))
                {
                    context.Vehiculos.Add(new Vehiculo
                    {
                        Matricula = "0000 MMM",
                        Modelo = "Focus",
                        Motorizacion = "Gasolina",
                        Motor = "1.0L EcoBoost",
                        Color = "Azul",
                        Fecha_matriculacion = new DateTime(2021, 5, 15).ToUniversalTime(),
                        FotoUrl = "/Focus.png",
                        Cliente = cliente,
                        Fabricante = fabricanteFord
                    });
                }
            }
            context.SaveChanges();
        }

        private static void SeedCitas(AppDbContext context)
        {
            // Obtener empleado, cliente y vehículo necesarios para la cita
            var empleado = context.Personas.OfType<Empleado>().FirstOrDefault(e => e.Nombre == "Daniel");
            var cliente = context.Personas.OfType<Cliente>().FirstOrDefault(c => c.Nombre == "Maikel");
            var vehiculo = context.Vehiculos.FirstOrDefault(v => v.Matricula == "1234ABC");

            // Verificar que las entidades necesarias existen
            if (empleado != null && cliente != null && vehiculo != null)
            {
                // Fecha y hora para la nueva cita
                var fechaCita = new DateTime(2021, 6, 15).ToUniversalTime();
                var horaCita = new Hora(new DateTime(2021, 6, 15, 10, 30, 0)); // Hora: 10:30 AM

                // Obtener las citas existentes en memoria para evitar problemas de traducción
                var citasExistentes = context.Citas
                    .Include(c => c.Fecha)
                    .Include(c => c.Hora)
                    .AsEnumerable();

                // Verificar si ya existe una cita con la misma fecha y hora
                if (!context.Citas.Any(c =>
                    c.Id_cliente == cliente.Id &&
                    c.Id_empleado == empleado.Id &&
                    c.Id_vehiculo == vehiculo.Id &&
                    c.Fecha.Año == fechaCita.Year &&
                    c.Fecha.Mes == fechaCita.Month &&
                    c.Fecha.Dia == fechaCita.Day &&
                    c.Hora.Horas == horaCita.Horas &&
                    c.Hora.Minutos == horaCita.Minutos))
                {
                    // Crear y añadir la nueva cita
                    var nuevaCita = new Cita
                    {
                        Fecha = new Fecha(fechaCita), // Crear el objeto Fecha a partir del DateTime
                        Hora = horaCita,             // Asignar la hora de la cita como un objeto Hora
                        Empleado = empleado,
                        Cliente = cliente,
                        Vehiculo = vehiculo
                    };
                    context.Citas.Add(nuevaCita);
                }
            }

            // Guardar cambios en la base de datos
            context.SaveChanges();
        }

        public static void SeedFacturas(AppDbContext context)
        {
            // Buscar cliente y vehículo
            var cliente = context.Personas.OfType<Cliente>().FirstOrDefault(c => c.Nombre == "Maikel");
            var vehiculo = context.Vehiculos.FirstOrDefault(v => v.Matricula == "1234ABC");

            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }
            
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            // Buscar cita asociada al cliente
            var cita = context.Citas.FirstOrDefault(c => c.Cliente.Id == cliente.Id);
            if (cita == null)
            {
                Console.WriteLine("Cita no encontrada.");
                return;
            }

            // Verificar si ya existe una factura para esta cita
            var facturaExistente = context.Facturas.FirstOrDefault(f => f.Id_cita == cita.Id);
            
            if (facturaExistente == null)
            {
                // Si no existe, crear una nueva factura
                var nuevaFactura = new Factura
                {
                    Id_cliente = cliente.Id,
                    Cliente = cliente,
                    Id_cita = cita.Id,
                    Cita = cita,
                    VehiculoId = vehiculo.Id,  // Asegurarse de que VehiculoId esté correctamente asignado
                    Vehiculo = vehiculo,
                    Precio = 200,
                    Descuento = 10,
                    Total = 190
                };

                // Inicializar listas vacías para evitar problemas con EF Core
                nuevaFactura.FacturaServicios = new List<FacturaServicio>();
                nuevaFactura.FacturaPiezas = new List<FacturaPieza>();

                context.Facturas.Add(nuevaFactura);
                context.SaveChanges();
                Console.WriteLine($"Factura creada con Id_cita = {cita.Id} y VehiculoId = {vehiculo.Id}");
            }
            else
            {
                // Si la factura ya existe, puedes elegir actualizarla o eliminarla
                Console.WriteLine("Ya existe una factura para esta cita. Puedes actualizarla o eliminarla.");
                
                // Opción 1: Eliminar la factura existente si no quieres duplicados
                // context.Facturas.Remove(facturaExistente);
                // context.SaveChanges();
                
                // Opción 2: Actualizar la factura existente
                facturaExistente.Precio = 200;
                facturaExistente.Descuento = 10;
                facturaExistente.Total = 190;
                facturaExistente.VehiculoId = vehiculo.Id; // Actualizar vehículo si es necesario
                
                context.SaveChanges();
                Console.WriteLine("Factura existente actualizada.");
            }
        }

    }
}
