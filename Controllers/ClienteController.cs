using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;
using LeganesCustomsBlazor.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;


namespace LeganesCustomsBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext  _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ClienteController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        // Get 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Vehiculos) // Incluye vehículos asociados
                .ThenInclude(v => v.Fabricante)
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
                        Fabricante = v.Fabricante != null ? v.Fabricante.Nombre : "Desconocido" // Cambiar operador ?. por una comprobación explícita
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
                DNI = cliente.DNI, 
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
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
        public async Task<IActionResult> CreateCliente(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos no válidos.");
            }

            try
            {
                // Crear un IdentityUser
                var identityUser = new IdentityUser
                {
                    UserName = clienteDto.Email,
                    Email = clienteDto.Email
                };

                var createUserResult = await _userManager.CreateAsync(identityUser, clienteDto.Password);
                if (!createUserResult.Succeeded)
                {
                    var errors = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                    return BadRequest(new { message = $"Error al crear usuario: {errors}" });
                }

                // Asignar el rol "Cliente"
                var addRoleResult = await _userManager.AddToRoleAsync(identityUser, "Cliente");
                if (!addRoleResult.Succeeded)
                {
                    var errors = string.Join(", ", addRoleResult.Errors.Select(e => e.Description));
                    return BadRequest(new { message = $"Error al asignar rol: {errors}" });
                }

                // Crear el cliente en la base de datos
                var cliente = new Cliente
                {
                    Nombre = clienteDto.Nombre,
                    Apellido1 = clienteDto.Apellido1,
                    Apellido2 = clienteDto.Apellido2,
                    DNI = clienteDto.DNI,
                    Email = clienteDto.Email,
                    Telefono = clienteDto.Telefono,
                    Direccion = clienteDto.Direccion,
                    IdentityUserId = identityUser.Id
                };

                _context.Clientes.Add(cliente);

                // Asociar los vehículos seleccionados
                if (clienteDto.Vehiculos != null && clienteDto.Vehiculos.Any())
                {
                    foreach (var vehiculoDto in clienteDto.Vehiculos)
                    {
                        var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.Id == vehiculoDto.Id_Vehiculo);
                        if (vehiculo == null)
                        {
                            return NotFound($"Vehículo con ID {vehiculoDto.Id_Vehiculo} no encontrado.");
                        }

                        vehiculo.Cliente = cliente;
                    }
                }

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id_Cliente }, clienteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al crear el cliente: {ex.Message}");
            }
        }

       [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClienteAsync(long id, ClienteDto clienteDto)
    {
        try
        {
            // Verifica que el cliente existe
            var clienteExistente = await _context.Clientes
                .Include(c => c.Vehiculos) // Incluye vehículos asociados
                .FirstOrDefaultAsync(c => c.Id_Cliente == id);

            if (clienteExistente == null)
            {
                return NotFound($"Cliente con ID {id} no encontrado.");
            }

            // Actualiza los datos del cliente
            clienteExistente.Nombre = clienteDto.Nombre ?? clienteExistente.Nombre;
            clienteExistente.Apellido1 = clienteDto.Apellido1 ?? clienteExistente.Apellido1;
            clienteExistente.Apellido2 = clienteDto.Apellido2 ?? clienteExistente.Apellido2;
            clienteExistente.Email = clienteDto.Email ?? clienteExistente.Email;
            clienteExistente.Telefono = clienteDto.Telefono ?? clienteExistente.Telefono;
            clienteExistente.Direccion = clienteDto.Direccion ?? clienteExistente.Direccion;

            // Asocia el vehículo si hay un ID de vehículo
            if (clienteDto.Vehiculos.Any())
            {
                var vehiculoDto = clienteDto.Vehiculos.First();
                var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.Id == vehiculoDto.Id_Vehiculo);

                if (vehiculo == null)
                {
                    return NotFound($"Vehículo con ID {vehiculoDto.Id_Vehiculo} no encontrado.");
                }

                vehiculo.Id_cliente = clienteExistente.Id_Cliente; // Asociar cliente al vehículo
                _context.Vehiculos.Update(vehiculo);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ClienteExists(id))
            {
                return NotFound($"Cliente con ID {id} no existe.");
            }
            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inesperado al actualizar cliente: {ex.Message}");
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
