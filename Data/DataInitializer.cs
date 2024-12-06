using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LeganesCustomsBlazor.Data
{
    public static class DataInitializer
    {
        public static void SeedData(AppDbContext context)
        {
            // Verificar si ya hay datos antes de insertar
            if (!context.Fabricantes.Any()) SeedFabricantes(context);

            // Inicializa clientes
            if (!context.Clientes.Any()) SeedClientes(context);

            // Inicializa empleados
            if (!context.Empleados.Any()) SeedEmpleados(context);

            // Inicializa vehículos
            if (!context.Vehiculos.Any()) SeedVehiculos(context);

            // Inicializa citas
            if (!context.Citas.Any()) SeedCitas(context);

            // Inicializa facturas
            if (!context.Facturas.Any()) SeedFacturas(context);
        }

        private static void SeedFabricantes(AppDbContext context)
        {
            Console.WriteLine("Ejecutando SeedFabricantes...");
            if (!context.Fabricantes.Any())
            {
                var fabricantes = new List<Fabricante>
                {
                    new Fabricante { Nombre = "Alpine", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi ", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Dacia", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lada", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Renault", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Nissan", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Mitsubishi", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Infiniti", Grupo = new Grupo { Nombre = "Renault-Nissan-Mitsubishi", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Mini", Grupo = new Grupo { Nombre = "BMW Group", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Rolls Royce", Grupo = new Grupo { Nombre = "BMW Group", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "BMW", Grupo = new Grupo { Nombre = "BMW Group", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Ferrari", Grupo = new Grupo { Nombre = "Ferrari", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Ford", Grupo = new Grupo { Nombre = "Ford Motor Company", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lincoln", Grupo = new Grupo { Nombre = "Ford Motor Company", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lotus", Grupo = new Grupo { Nombre = "Geely", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Geely", Grupo = new Grupo { Nombre = "Geely", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lynk&Co", Grupo = new Grupo { Nombre = "Geely", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Polestar", Grupo = new Grupo { Nombre = "Geely", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Volvo", Grupo = new Grupo { Nombre = "Geely", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Buick", Grupo = new Grupo { Nombre = "General Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Cadillac", Grupo = new Grupo { Nombre = "General Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Chevrolet", Grupo = new Grupo { Nombre = "General Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "GMC", Grupo = new Grupo { Nombre = "General Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Alfa Romeo", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Fiat", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lancia", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Maserati", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Jeep", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Chrysler", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Dodge", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Peugeot", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Citröen", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "DS Automobiles", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Opel", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Vauxhall", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Abarth", Grupo = new Grupo { Nombre = "Grupo Stellantis", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Aiways", Grupo = new Grupo { Nombre = "Aiways", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Aston Martin", Grupo = new Grupo { Nombre = "Aston Martin Lagonda Global Holdings PLC", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Bugatti", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "BYD", Grupo = new Grupo { Nombre = "BYD Company Limited", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Caterham", Grupo = new Grupo { Nombre = "VT Holdings", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "DR Automobile", Grupo = new Grupo { Nombre = "DR Automobiles Groupe", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Isuzu", Grupo = new Grupo { Nombre = "Isuzu Motors Ltd.", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Jaecoo", Grupo = new Grupo { Nombre = "Chery", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Koenigsegg", Grupo = new Grupo { Nombre = "Koenigsegg Automotive AB", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "KTM", Grupo = new Grupo { Nombre = "KTM Group", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "McLaren", Grupo = new Grupo { Nombre = "McLaren Group", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Mercedes-Benz", Grupo = new Grupo { Nombre = "Mercedes-Benz Group AG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "MG", Grupo = new Grupo { Nombre = "SAIC Motor", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Morgan", Grupo = new Grupo { Nombre = "Morgan Motor Company Ltd.", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Omoda", Grupo = new Grupo { Nombre = "Chery", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Rimac", Grupo = new Grupo { Nombre = "Rimac Automobili", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Smart", Grupo = new Grupo { Nombre = "Mercedes-Benz Group AG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Acura", Grupo = new Grupo { Nombre = "Honda Motor Company Limited", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Honda", Grupo = new Grupo { Nombre = "Honda Motor Company Limited", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Kia", Grupo = new Grupo { Nombre = "Hyundai Motor Company", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Hyundai", Grupo = new Grupo { Nombre = "Hyundai Motor Company", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Genesis", Grupo = new Grupo { Nombre = "Hyundai Motor Company", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Mazda", Grupo = new Grupo { Nombre = "Mazda Motor Corporation", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Subaru", Grupo = new Grupo { Nombre = "Subaru Corporation", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Suzuki", Grupo = new Grupo { Nombre = "Suzuki Motor Corporation", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Jaguar", Grupo = new Grupo { Nombre = "Tata Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Land Rover", Grupo = new Grupo { Nombre = "Tata Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Tata Motors", Grupo = new Grupo { Nombre = "Tata Motors", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Tesla", Grupo = new Grupo { Nombre = "Tesla Inc.", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Toyota", Grupo = new Grupo { Nombre = "Toyota Motor Corporation", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Daihatsu", Grupo = new Grupo { Nombre = "Toyota Motor Corporation", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lexus", Grupo = new Grupo { Nombre = "Toyota Motor Corporation", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Audi", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Bentley", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Cupra", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Lamborghini", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Porsche", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "SEAT", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Skoda", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Volkswagen", Grupo = new Grupo { Nombre = "Grupo VAG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "SsangYong", Grupo = new Grupo { Nombre = " KG", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },
                    new Fabricante { Nombre = "Otros", Grupo = new Grupo { Nombre = "Otros", Fabricantes = new List<Fabricante>() }, Vehiculos = new List<Vehiculo>() },

            };

            context.Fabricantes.AddRange(fabricantes);
            context.SaveChanges();
            Console.WriteLine("Fabricantes añadidos a la base de datos.");
        }
        else
        {
            Console.WriteLine("Los fabricantes ya existen en la base de datos.");
        }
    }

        private static void SeedClientes(AppDbContext context)
        {
            var cliente = context.Clientes.OfType<Cliente>().FirstOrDefault(c => c.Nombre == "Maikel");
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
                context.Clientes.Add(cliente);
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
            var empleado = context.Empleados.OfType<Empleado>().FirstOrDefault(e => e.Nombre == "Daniel");
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
                context.Empleados.Add(empleado);
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
