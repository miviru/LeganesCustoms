using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;
using LeganesCustomsBlazor.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeganesCustomsBlazor.Services
{
    public class CitaService : ICitasService
    {
        private readonly AppDbContext _context;

        public CitaService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las citas
        public async Task<IEnumerable<CitaDto>> GetAllCitasAsync()
        {
            var citas = await _context.Citas
                .Include(c => c.Fecha)
                .Include(c => c.Hora)
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Vehiculo)
                .Include(c => c.Piezas)
                .Select(c => new CitaDto
                {
                    Id = c.Id,
                    Fecha = c.Fecha.ToDateTime(),
                    Hora = c.Hora.HoraCompleta.ToString("hh\\:mm"),
                    ClienteNombre = c.Cliente.Nombre,
                    ClienteApellido = c.Cliente.Apellido1, // Revisar aquí si Apellido1 existe
                    EmpleadoNombre = c.Empleado.Nombre,
                    VehiculoDetalles = $"{c.Vehiculo.Fabricante} {c.Vehiculo.Modelo} - Matrícula {c.Vehiculo.Matricula}",
                    Piezas = c.Piezas
                        .Select(p => p.Nombre)
                        .Where(nombre => nombre != null)
                        .Select(nombre => nombre!)
                        .ToList()
                })
                .ToListAsync();

            // Log temporal para depurar valores de ClienteApellido
            foreach (var cita in citas)
            {
                Console.WriteLine($"Cita Id: {cita.Id}, ClienteApellido: {cita.ClienteApellido}");
            }

            return citas;
        }

        // Obtener una cita por ID
        public async Task<CitaDto?> GetCitaByIdAsync(long id)
        {
            var cita = await _context.Citas
                .Include(c => c.Fecha)
                .Include(c => c.Hora)
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Vehiculo)
                .ThenInclude(v => v.Fabricante)
                .Include(c => c.Servicios)
                .Include(c => c.Factura)
                .Include(c => c.Piezas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cita == null) return null;

            return new CitaDto
            {
                Id = cita.Id,
                Fecha = cita.Fecha.ToDateTime(),
                Hora = cita.Hora.HoraCompleta.ToString("hh\\:mm"),
                ClienteNombre = cita.Cliente.Nombre,
                ClienteApellido = cita.Cliente.Apellido1,
                ClienteApellido2 = cita.Cliente.Apellido2,
                DNI = cita.Cliente.DNI,
                EmpleadoNombre = cita.Empleado.Nombre,
                VehiculoDetalles = $"{cita.Vehiculo.Fabricante.Nombre} {cita.Vehiculo.Modelo} - {cita.Vehiculo.Matricula}",
                IdVehiculo = cita.Vehiculo.Id,
                Servicios = cita.Servicios
                    .Select(s => s.Nombre!) // Garantiza que no es nulo
                    .ToList(), 
                Piezas = cita.Piezas
                    .Select(p => p.Nombre)
                    .Where(nombre => nombre != null)  
                    .Select(nombre => nombre!)
                    .ToList(),
                FacturaNumero = cita.Factura?.Id.ToString(), // Número de factura
                FacturaTotal = cita.Factura?.Total ?? 0 // Total de la factura
            };
        }

        // Crear una nueva cita
       public async Task<CitaDto> CreateCitaAsync(CitaDto citaDto)
        {
            // Validar Cliente
            Cliente? cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nombre == citaDto.ClienteNombre);
            if (cliente == null)
            {
                throw new Exception($"No se encontró un cliente con el nombre '{citaDto.ClienteNombre}'.");
            }

            // Validar Empleado
            Empleado? empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Nombre == citaDto.EmpleadoNombre);
            if (empleado == null)
            {
                throw new Exception($"No se encontró un empleado con el nombre '{citaDto.EmpleadoNombre}'.");
            }

            // Validar Vehículo
            // Realiza la manipulación de cadenas en la aplicación
            var matricula = citaDto.VehiculoDetalles.Split('-').Last().Trim();

            // Usa el valor preprocesado en la consulta
            Vehiculo? vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.Matricula == matricula);

            if (vehiculo == null)
            {
                throw new Exception($"No se encontró un vehículo con la matrícula proporcionada.");
            }


            // Crear la cita
            var cita = new Cita
            {
                Fecha = new Fecha(citaDto.Fecha),
                Hora = new Hora(DateTime.Parse(citaDto.Hora)),
                Cliente = cliente,
                Empleado = empleado,
                Vehiculo = vehiculo
            };

            // Agregar y guardar la cita
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            // Retornar el DTO actualizado con el ID generado
            citaDto.Id = cita.Id;
            return citaDto;
        }

        // Actualizar una cita existente
        public async Task<bool> UpdateCitaAsync(long id, CitaDto citaDto)
        {
            // Busca la cita existente con las relaciones necesarias
            var cita = await _context.Citas
                .Include(c => c.Fecha)
                .Include(c => c.Hora)
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cita == null) return false;

            // Validar y actualizar Cliente
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nombre == citaDto.ClienteNombre);
            if (cliente == null)
            {
                throw new Exception($"No se encontró un cliente con el nombre '{citaDto.ClienteNombre}'.");
            }

            // Validar y actualizar Empleado
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Nombre == citaDto.EmpleadoNombre);
            if (empleado == null)
            {
                throw new Exception($"No se encontró un empleado con el nombre '{citaDto.EmpleadoNombre}'.");
            }

            // Validar y actualizar Vehículo
            var matricula = citaDto.VehiculoDetalles.Split('-').Last().Trim();
            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.Matricula == matricula);
            if (vehiculo == null)
            {
                throw new Exception($"No se encontró un vehículo con la matrícula '{matricula}'.");
            }

            // Actualizar campos de la cita
            cita.Fecha = new Fecha(citaDto.Fecha); // Crear nueva instancia de Fecha usando el constructor
            cita.Hora = new Hora(DateTime.Parse(citaDto.Hora)); // Crear nueva instancia de Hora
            cita.Cliente = cliente;
            cita.Empleado = empleado;
            cita.Vehiculo = vehiculo;

            // Marcar la entidad como modificada
            _context.Citas.Update(cita);

            // Guardar los cambios
            await _context.SaveChangesAsync();

            return true;
        }

        // Eliminar una cita
        public async Task<bool> DeleteCitaAsync(long id)
        {
            var cita = await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Cita>> GetCitasPorEmpleadoAsync(long empleadoId)
        {
            return await _context.Citas
                .Where(c => c.Empleado.Id == empleadoId)
                .ToListAsync();
        }

        public async Task<List<Cita>> GetCitasPorClienteIdAsync(long clienteId)
        {
            return await _context.Citas
                .Include(c => c.Vehiculo)
                .Include(c => c.Empleado)
                .Include(c => c.Cliente)
                .Where(c => c.Cliente.Id == clienteId)
                .ToListAsync();
        }

    }
}

