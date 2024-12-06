using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;
using Newtonsoft.Json;



namespace LeganesCustomsBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext  _context;

        public ClienteController(AppDbContext  context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Get 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Vehiculos) // Incluye vehículos asociados
                .Select(c => new ClienteDto
                {
                    Id_Cliente = c.Id_Cliente,
                    Nombre = c.Nombre,
                    Apellido1 = c.Apellido1,
                    Apellido2 = c.Apellido2,
                    DNI = c.DNI,
                    Email = c.Email,
                    Vehiculos = c.Vehiculos.Select(v => new VehiculoDto
                    {
                        Id_Vehiculo = v.Id,
                        Matricula = v.Matricula,
                        Modelo = v.Modelo,
                        Fabricante = v.Fabricante != null ? v.Fabricante.Nombre : string.Empty
                    }).ToList()
                })
                .ToListAsync();

            return Ok(clientes);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(long id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Vehiculos) // Incluir vehículos asociados
                .ThenInclude(v => v.Fabricante) // Incluir datos del fabricante si es necesario
                .FirstOrDefaultAsync(c => c.Id_Cliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = new ClienteDto
            {
                Id_Cliente = cliente.Id_Cliente,
                Nombre = cliente.Nombre,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Vehiculos = cliente.Vehiculos.Select(v => new VehiculoDto
                {
                    Id_Vehiculo = v.Id,
                    Matricula = v.Matricula,
                    Modelo = v.Modelo,
                    Fabricante = v.Fabricante?.Nombre ?? "Desconocido"
                }).ToList()
            };

            return Ok(clienteDto);
        }

        // POST: api/Cliente
       [HttpPost]
        public async Task<ActionResult<ClienteDto>> CreateCliente(ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("El cliente no puede ser nulo.");
            }

            // Mapear ClienteDto a Cliente
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido1 = clienteDto.Apellido1,
                Apellido2 = clienteDto.Apellido2,
                DNI = clienteDto.DNI,
                Email = clienteDto.Email ?? string.Empty,
                Telefono = clienteDto.Telefono ?? string.Empty,
                Direccion = clienteDto.Direccion
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            clienteDto.Id_Cliente = cliente.Id_Cliente;

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id_Cliente }, clienteDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClienteAsync(long id, ClienteDto clienteDto)
        {
            try
            {
                Console.WriteLine($"ID URL: {id}, ID DTO: {clienteDto.Id_Cliente}");
                if (id != clienteDto.Id_Cliente)
                {
                    Console.WriteLine($"Error: ID URL ({id}) no coincide con ID DTO ({clienteDto.Id_Cliente}).");
                    return BadRequest("El ID del cliente no coincide con el ID proporcionado en el DTO.");
                }

                var clienteExistente = await _context.Clientes.FirstOrDefaultAsync(e => e.Id_Cliente == id);

                if (clienteExistente == null)
                {
                    Console.WriteLine($"Error: No se encontró un cliente con ID {id}.");
                    return NotFound($"No se encontró un cliente con ID {id}.");
                }

                Console.WriteLine($"Cliente encontrado: {JsonConvert.SerializeObject(clienteExistente)}");

                // Solo actualiza los campos que se envían en el DTO
                clienteExistente.Nombre = clienteDto.Nombre ?? clienteExistente.Nombre;
                clienteExistente.Apellido1 = clienteDto.Apellido1 ?? clienteExistente.Apellido1;
                clienteExistente.Apellido2 = clienteDto.Apellido2 ?? clienteExistente.Apellido2;
                clienteExistente.DNI = clienteDto.DNI ?? clienteExistente.DNI;
                clienteExistente.Email = clienteDto.Email ?? clienteExistente.Email;
                clienteExistente.Telefono = clienteDto.Telefono ?? clienteExistente.Telefono;
                clienteExistente.Direccion = clienteDto.Direccion ?? clienteExistente.Direccion;

                await _context.SaveChangesAsync();
                Console.WriteLine($"Cliente con ID {id} actualizado correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClienteExists(id))
                {
                    Console.WriteLine($"Error: Concurrencia detectada. El cliente con ID {id} no existe.");
                    return NotFound($"Cliente con ID {id} no existe.");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
                return StatusCode(500, "Ocurrió un error interno al actualizar el cliente.");
            }
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(long id)
        {
            try
            {
                if (_context.Clientes == null)
                {
                    return Problem("El contexto no está disponible.");
                }

                var cliente = await _context.Clientes.FirstOrDefaultAsync(e => e.Id_Cliente == id);
                if (cliente == null)
                {
                    return NotFound($"Cliente con ID {id} no existe.");
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el cliente: {ex.Message}");
                return StatusCode(500, "Ocurrió un error interno al eliminar el cliente.");
            }
        }

        private async Task<bool> ClienteExists(long id)
        {
            if (_context.Clientes == null)
            {
                throw new InvalidOperationException("Clientes no está configurado en el contexto.");
            }

            return await _context.Clientes.AnyAsync(c => c.Id_Cliente == id);
        }

        private ClienteDto MapToClienteDto(Cliente cliente)
        {
            return new ClienteDto
            {
                Id_Cliente = cliente.Id_Cliente,
                Nombre = cliente.Nombre,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                DNI = cliente.DNI,
                Email = cliente.Email,
                Telefono = cliente.Telefono ?? string.Empty,
                Direccion = cliente.Direccion ?? string.Empty,
                Vehiculos = cliente.Vehiculos.Select(v => new VehiculoDto
                {
                    Id_Vehiculo = v.Id,
                    Fabricante = v.Fabricante.Nombre,
                    Modelo = v.Modelo,
                    Matricula = v.Matricula,
                    Fecha_matriculacion = v.Fecha_matriculacion
                }).ToList(),
                Citas = cliente.Citas?.Select(ci => new CitaDto
                {
                    Id = ci.Id,
                    Fecha = ci.Fecha != null 
                        ? new DateTime(ci.Fecha.Año, ci.Fecha.Mes, ci.Fecha.Dia) 
                        : DateTime.MinValue,
                    Hora = $"{ci.Hora.Horas:D2}:{ci.Hora.Minutos:D2}",
                    ClienteNombre = ci.Cliente?.Nombre ?? "Sin Nombre",
                    EmpleadoNombre = ci.Empleado?.Nombre ?? "Sin Empleado",
                    VehiculoDetalles = $"{ci.Vehiculo?.Fabricante?.Nombre ?? "Desconocida"} {ci.Vehiculo?.Modelo ?? "Desconocido"}"
                }).ToList() ?? new List<CitaDto>(),
                Facturas = cliente.Facturas.Select(f => new FacturaDto
                {
                    Id = f.Id,
                    Precio = f.Precio,
                    Descuento = f.Descuento,    
                    ClienteNombre = f.Cliente?.Nombre ?? "Sin Nombre"
                }).ToList()
            };
        }
    }
}
