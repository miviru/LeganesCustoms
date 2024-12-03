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
    public class EmpleadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpleadoController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetEmpleados()
        {
            try
            {
                if (_context.Empleados == null)
                {
                    return Problem("El contexto no está disponible.");
                }

                var empleados = await _context.Empleados
                    .AsNoTracking()
                    .Include(e => e.Citas)
                    .ToListAsync();

                if (!empleados.Any())
                {
                    Console.WriteLine("No se encontraron empleados.");
                    return Ok(new List<EmpleadoDto>());
                }

                var empleadosDto = empleados.Select(MapToEmpleadoDto).ToList();
                return Ok(empleadosDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                return StatusCode(500, new ProblemDetails
                {
                    Status = 500,
                    Title = "Error interno del servidor",
                    Detail = ex.Message
                });
            }
        }

        // GET: api/Empleado/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(long id)
        {
            try
            {
                if (_context.Empleados == null)
                {
                    return Problem("El contexto no está disponible.");
                }

                var empleado = await _context.Empleados
                    .AsNoTracking()
                    .Include(e => e.Citas)
                    .FirstOrDefaultAsync(c => c.Id_Empleado == id);

                if (empleado == null)
                {
                    return NotFound(new ProblemDetails
                    {
                        Status = 404,
                        Title = "Empleado no encontrado",
                        Detail = $"No existe un empleado con ID {id}."
                    });
                }

                return Ok(MapToEmpleadoDto(empleado));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleado con ID {id}: {ex.Message}");
                return StatusCode(500, "Ocurrió un error interno al obtener el empleado.");
            }
        }

        // POST: api/Empleado
        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> CreateEmpleado(EmpleadoDto empleadoDto)
        {
            try
            {
                if (empleadoDto == null)
                {
                    return BadRequest("El empleado no puede ser nulo.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var empleado = new Empleado
                {
                    Nombre = empleadoDto.Nombre,
                    Apellido1 = empleadoDto.Apellido1,
                    Apellido2 = empleadoDto.Apellido2,
                    DNI = empleadoDto.DNI,
                    Email = empleadoDto.Email,
                    Telefono = empleadoDto.Telefono,
                    Direccion = empleadoDto.Direccion,
                    Puesto = empleadoDto.Puesto,
                    Sueldo = empleadoDto.Sueldo
                };

                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                empleadoDto.Id_Empleado = empleado.Id_Empleado;

                return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id_Empleado }, empleadoDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear empleado: {ex.Message}");
                return StatusCode(500, "Ocurrió un error interno al crear el empleado.");
            }
        }

        // PUT: api/Empleado/{id}
        [HttpPut("{id}")]
public async Task<IActionResult> UpdateEmpleadoAsync(long id, EmpleadoDto empleadoDto)
{
    try
    {
        if (id != empleadoDto.Id_Empleado)
        {
            Console.WriteLine($"Error: ID URL ({id}) no coincide con ID DTO ({empleadoDto.Id_Empleado}).");
            return BadRequest("El ID del empleado no coincide con el ID proporcionado en el DTO.");
        }

        _context.ChangeTracker.Clear(); // Limpia el contexto
        var empleadoExistente = await _context.Empleados
            .FirstOrDefaultAsync(e => e.Id_Empleado == id);

        if (empleadoExistente == null)
        {
            Console.WriteLine($"Error: No se encontró un empleado con ID {id}.");
            return NotFound($"No se encontró un empleado con ID {id}.");
        }

        Console.WriteLine($"Empleado encontrado: {JsonConvert.SerializeObject(empleadoExistente)}");

        empleadoExistente.Email = empleadoDto.Email ?? empleadoExistente.Email;
        empleadoExistente.Telefono = empleadoDto.Telefono ?? empleadoExistente.Telefono;
        empleadoExistente.Direccion = empleadoDto.Direccion ?? empleadoExistente.Direccion;
        empleadoExistente.Puesto = empleadoDto.Puesto ?? empleadoExistente.Puesto;
        empleadoExistente.Sueldo = empleadoDto.Sueldo;

        await _context.SaveChangesAsync();
        Console.WriteLine($"Empleado con ID {id} actualizado correctamente.");

        return NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!await EmpleadoExists(id))
        {
            Console.WriteLine($"Error: Concurrencia detectada. El empleado con ID {id} no existe.");
            return NotFound($"Empleado con ID {id} no existe.");
        }
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
        return StatusCode(500, "Ocurrió un error interno al actualizar el empleado.");
    }
}

        // DELETE: api/Empleado/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> TestDelete(long id)
        {
            try
            {
                if (_context.Empleados == null)
                {
                    return Problem("El contexto no está disponible.");
                }

                var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id_Empleado == id);
                if (empleado == null)
                {
                    return NotFound($"Empleado con ID {id} no existe.");
                }

                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el empleado: {ex.Message}");
                return StatusCode(500, "Ocurrió un error interno al eliminar el empleado.");
            }
        }

        private async Task<bool> EmpleadoExists(long id)
        {
            return await _context.Empleados.AnyAsync(c => c.Id_Empleado == id);
        }

        private EmpleadoDto MapToEmpleadoDto(Empleado empleado)
        {
            return new EmpleadoDto
            {
                Id_Empleado = empleado.Id_Empleado,
                Nombre = empleado.Nombre ?? string.Empty,
                Apellido1 = empleado.Apellido1 ?? string.Empty,
                Apellido2 = empleado.Apellido2 ?? string.Empty,
                DNI = empleado.DNI ?? string.Empty,
                Email = empleado.Email ?? string.Empty,
                Telefono = empleado.Telefono ?? string.Empty,
                Direccion = empleado.Direccion ?? string.Empty,
                Puesto = empleado.Puesto ?? string.Empty,
                Sueldo = empleado.Sueldo,
                Citas = empleado.Citas?.Select(c => new CitaDto
                {
                    Fecha = c.Fecha != null
                        ? new DateTime(c.Fecha.Año, c.Fecha.Mes, c.Fecha.Dia)
                        : DateTime.MinValue
                }).ToList() ?? new List<CitaDto>()
            };
        }
    }
}
