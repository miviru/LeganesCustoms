using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;



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
            if (_context.Clientes == null)
            {
                return Problem("Clientes no está disponible en el contexto.");
            }

            try
            {
                var clientes = await _context.Clientes
                    .Include(c => c.Vehiculos)
                    .Include(c => c.Citas)
                    .Include(c => c.Facturas)
                    .ToListAsync();

                if (!clientes.Any())
                {
                    Console.WriteLine("No se encontraron clientes en la base de datos.");
                    return Ok(new List<ClienteDto>()); // Devuelve una lista vacía
                }

                // Transformar a ClienteDto
                var clientesDto = clientes.Select(c => new ClienteDto
                {
                    Id_Cliente = c.Id_Cliente,
                    Nombre = c.Nombre ?? string.Empty,
                    Apellido1 = c.Apellido1 ?? string.Empty,
                    Apellido2 = c.Apellido2 ?? string.Empty,
                    DNI = c.DNI ?? string.Empty,
                    Email = c.Email ?? string.Empty,
                    Vehiculos = c.Vehiculos?.Select(v => new VehiculoDto
                    {
                        Matricula = v.Matricula ?? string.Empty,
                        Modelo = v.Modelo ?? string.Empty,
                        Fabricante = v.Fabricante?.Nombre ?? string.Empty
                    }).ToList() ?? new List<VehiculoDto>(),
                    Citas = c.Citas?.Select(c => new CitaDto
                    {
                        Fecha = c.Fecha != null
                            ? new DateTime(c.Fecha.Año, c.Fecha.Mes, c.Fecha.Dia)
                            : DateTime.MinValue
                    }).ToList() ?? new List<CitaDto>(),
                    Facturas = c.Facturas?.Select(f => new FacturaDto
                    {
                        Precio = f.Precio,
                        Descuento = f.Descuento,
                        ClienteNombre = f.Cliente?.Nombre ?? string.Empty
                    }).ToList() ?? new List<FacturaDto>()
                }).ToList();

                return Ok(clientesDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                return Problem("Ocurrió un error al intentar obtener los clientes.");
            }
        }


        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(long id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Clientes no está disponible en el contexto.");
            }

            var cliente = await _context.Clientes
                .Include(c => c.Vehiculos)
                    .ThenInclude(v => v.Fabricante)
                .Include(c => c.Citas)
                .Include(c => c.Facturas)
                .FirstOrDefaultAsync(c => c.Id_Cliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            // Transformar Cliente a ClienteDto
            var clienteDto = new ClienteDto
            {
                Id_Cliente = cliente.Id_Cliente,
                Nombre = cliente.Nombre,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                DNI = cliente.DNI,
                Email = cliente.Email,
                Vehiculos = cliente.Vehiculos.Select(v => new VehiculoDto
                {
                    Id_Vehiculo = v.Id, // Mapea correctamente el ID del modelo al DTO
                    Matricula = v.Matricula,
                    Modelo = v.Modelo,
                    Fabricante = v.Fabricante != null ? v.Fabricante.Nombre : "Desconocido",
                    FotoUrl = v.FotoUrl
                }).ToList(),
                Citas = cliente.Citas?.Select(c => new CitaDto
                {
                    Fecha = c.Fecha != null 
                        ? new DateTime(c.Fecha.Año, c.Fecha.Mes, c.Fecha.Dia) 
                        : DateTime.MinValue // Fecha predeterminada si es nula
                }).ToList() ?? new List<CitaDto>(),
                Facturas = cliente.Facturas.Select(f => new FacturaDto
                {
                    Precio = f.Precio,
                    Descuento = f.Descuento,
                    ClienteNombre = f.Cliente?.Nombre ?? "Desconocido"
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
                Email = clienteDto.Email,
                Telefono = clienteDto.Telefono,
                Direccion = clienteDto.Direccion
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            clienteDto.Id_Cliente = cliente.Id_Cliente;

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id_Cliente }, clienteDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(long id, ClienteDto clienteDto)
        {
            // Verificar que el ID del cliente en la URL coincide con el del DTO
            if (id != clienteDto.Id_Cliente)
            {
                return BadRequest("El ID del cliente no coincide con el ID proporcionado en el DTO.");
            }

            // Validar que _context.Clientes no es nulo
            if (_context.Clientes == null)
            {
                return Problem("Clientes no está disponible en el contexto.");
            }

            // Buscar el cliente existente en la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente == null)
            {
                return NotFound("No se encontró el cliente especificado.");
            }

            // Actualizar manualmente los campos necesarios
            clienteExistente.Nombre = clienteDto.Nombre ?? clienteExistente.Nombre;
            clienteExistente.Apellido1 = clienteDto.Apellido1 ?? clienteExistente.Apellido1;
            clienteExistente.Apellido2 = clienteDto.Apellido2 ?? clienteExistente.Apellido2;
            clienteExistente.DNI = clienteDto.DNI ?? clienteExistente.DNI;
            clienteExistente.Email = clienteDto.Email ?? clienteExistente.Email;
            clienteExistente.Telefono = clienteDto.Telefono ?? clienteExistente.Telefono;
            clienteExistente.Direccion = clienteDto.Direccion ?? clienteExistente.Direccion;

            // Aquí puedes actualizar relaciones adicionales si son necesarias (por ejemplo, Vehiculos, Facturas, etc.)
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClienteExists(id))
                {
                    return NotFound("El cliente no existe.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(long id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Clientes no está disponible en el contexto.");
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound("No se encontró el cliente especificado.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private async Task<bool> ClienteExists(long id)
        {
            if (_context.Clientes == null)
            {
                throw new InvalidOperationException("Clientes no está configurado en el contexto.");
            }

            return await _context.Clientes.AnyAsync(c => c.Id_Cliente == id);
        }
    }
}
