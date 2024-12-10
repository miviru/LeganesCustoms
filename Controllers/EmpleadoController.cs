using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;


namespace LeganesCustomsBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmpleadoController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetEmpleados()
        {
            var empleados = await _context.Empleados
                .AsNoTracking()
                .Include(e => e.Citas)
                .ToListAsync();

            if (!empleados.Any())
            {
                return Ok(new List<EmpleadoDto>());
            }

            var empleadosDto = empleados.Select(MapToEmpleadoDto).ToList();
            return Ok(empleadosDto);
        }

        // GET: api/Empleado/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(long id)
        {
            var empleado = await _context.Empleados
                .AsNoTracking()
                .Include(e => e.Citas)
                .FirstOrDefaultAsync(e => e.Id_Empleado == id);

            if (empleado == null)
            {
                return NotFound(new { mensaje = $"Empleado con ID {id} no encontrado." });
            }

            return Ok(MapToEmpleadoDto(empleado));
        }

        // POST: api/Empleado
        [HttpPost]
        public async Task<IActionResult> CreateEmpleado(EmpleadoDto empleadoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos no válidos.");

            // Crear un IdentityUser
            var identityUser = new IdentityUser
            {
                UserName = empleadoDto.Email,
                Email = empleadoDto.Email
            };

            // Crear el usuario en Identity
            var result = await _userManager.CreateAsync(identityUser, empleadoDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }

            // Asignar el rol
            var role = empleadoDto.Puesto.ToUpperInvariant() switch
            {
                "MECÁNICO" => "EMPLEADOMECANICO",
                "RECEPCIONISTA" => "EMPLEADORECEPCIONISTA",
                _ => throw new InvalidOperationException($"Rol no definido para el puesto: {empleadoDto.Puesto}")
            };

            var roleResult = await _userManager.AddToRoleAsync(identityUser, role);
            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                return BadRequest($"Error al asignar rol: {errors}");
            }

            // Crear el empleado relacionado
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
                Sueldo = empleadoDto.Sueldo,
                IdentityUserId = identityUser.Id
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id_Empleado }, empleado);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(long id, EmpleadoDto empleadoDto)
        {
            // Verificar si el empleado existe
            var empleado = await _context.Empleados
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(e => e.Id_Empleado == id);

            if (empleado == null)
                return NotFound("Empleado no encontrado.");

            // Actualizar los datos básicos del empleado
            empleado.Nombre = empleadoDto.Nombre;
            empleado.Apellido1 = empleadoDto.Apellido1;
            empleado.Apellido2 = empleadoDto.Apellido2;
            empleado.DNI = empleadoDto.DNI;
            empleado.Telefono = empleadoDto.Telefono;
            empleado.Direccion = empleadoDto.Direccion;
            empleado.Puesto = empleadoDto.Puesto;
            empleado.Sueldo = empleadoDto.Sueldo;

            // Manejar la actualización de la contraseña
            if (!string.IsNullOrEmpty(empleadoDto.Password))
            {
                // Buscar el usuario en Identity
                var identityUser = await _userManager.FindByIdAsync(empleado.IdentityUserId);

                if (identityUser == null)
                    return NotFound("Usuario asociado al empleado no encontrado.");

                // Generar token de restablecimiento de contraseña
                var token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);

                // Cambiar la contraseña
                var result = await _userManager.ResetPasswordAsync(identityUser, token, empleadoDto.Password);

                if (!result.Succeeded)
                {
                    // Combinar y lanzar los errores si los hay
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return BadRequest($"Error al actualizar contraseña: {errors}");
                }
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Empleado/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleadoAsync(long id)
        {
            var empleado = await _context.Empleados
                .Include(e => e.Citas)
                .FirstOrDefaultAsync(e => e.Id_Empleado == id);
            if (empleado == null)
            {
                return NotFound($"Empleado con ID {id} no encontrado.");
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Empleado/logueado
        [Authorize(Roles = "EmpleadoMecanico,Admin")]
        [HttpGet("logueado")]
        public async Task<IActionResult> GetEmpleadoLogueado()
        {
            var usuarioActual = await _userManager.GetUserAsync(User);

            if (usuarioActual == null)
            {
                return Unauthorized("Usuario no autenticado.");
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Email == usuarioActual.Email);

            if (empleado == null)
            {
                return NotFound(new { mensaje = "Este usuario no está asociado a un empleado." });
            }

            return Ok(MapToEmpleadoDto(empleado));
        }

        // Helper Methods
        private async Task<bool> EmpleadoExists(long id)
        {
            return await _context.Empleados.AnyAsync(e => e.Id_Empleado == id);
        }

        private EmpleadoDto MapToEmpleadoDto(Empleado empleado)
        {
            return new EmpleadoDto
            {
                Id_Empleado = empleado.Id_Empleado,
                Nombre = empleado.Nombre,
                Apellido1 = empleado.Apellido1,
                Apellido2 = empleado.Apellido2,
                DNI = empleado.DNI,
                Email = empleado.Email,
                Telefono = empleado.Telefono,
                Direccion = empleado.Direccion,
                Puesto = empleado.Puesto,
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
