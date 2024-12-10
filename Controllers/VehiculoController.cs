using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;

namespace LeganesCustomsBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiculoController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/vehiculo
        [HttpGet]
        public async Task<ActionResult<List<VehiculoDto>>> GetVehiculos()
        {
            try
            {
                var vehiculos = await _context.Vehiculos
                    .Include(v => v.Fabricante)
                    .Select(v => new VehiculoDto
                    {
                        Id_Vehiculo = v.Id,
                        Matricula = v.Matricula,
                        Modelo = v.Modelo,
                        Fabricante = v.Fabricante.Nombre,
                        Motorizacion = v.Motorizacion,
                        Motor = v.Motor,
                        Fecha_matriculacion = v.Fecha_matriculacion,
                        Color = v.Color,
                        FotoUrl = v.FotoUrl
                    }).ToListAsync();

                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inesperado: {ex.Message}");
            }
        }

        // GET: api/vehiculo/{id}
        [HttpGet("{id:long}")]
        public async Task<ActionResult<VehiculoDto>> GetVehiculo(long id)
        {
            var vehiculo = await _context.Vehiculos
                .Include(v => v.Cliente) // Cargar cliente asociado
                .Include(v => v.Fabricante) // Si es necesario
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            var vehiculoDto = new VehiculoDto
            {
                Id_Vehiculo = vehiculo.Id,
                Matricula = vehiculo.Matricula,
                Modelo = vehiculo.Modelo,
                Fabricante = vehiculo.Fabricante?.Nombre ?? "Desconocido",
                Motorizacion = vehiculo.Motorizacion,
                Motor = vehiculo.Motor,
                Fecha_matriculacion = vehiculo.Fecha_matriculacion,
                Color = vehiculo.Color,
                FotoUrl = vehiculo.FotoUrl,
                Cliente = vehiculo.Cliente != null
                    ? new ClienteDto
                    {
                        Id_Cliente = vehiculo.Cliente.Id_Cliente,
                        Nombre = vehiculo.Cliente.Nombre,
                        Apellido1 = vehiculo.Cliente.Apellido1,
                        Apellido2 = vehiculo.Cliente.Apellido2,
                        Email = vehiculo.Cliente.Email,
                        Telefono = vehiculo.Cliente.Telefono
                    }
                    : null
            };

            return Ok(vehiculoDto);
        }

        // POST: api/vehiculo
        [HttpPost]
        public async Task<IActionResult> CrearVehiculo([FromBody] VehiculoDto vehiculoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear el nuevo vehículo
            var vehiculo = new Vehiculo
            {
                Matricula = vehiculoDto.Matricula,
                Modelo = vehiculoDto.Modelo,
                Motorizacion = vehiculoDto.Motorizacion,
                Motor = vehiculoDto.Motor,
                Fecha_matriculacion = vehiculoDto.Fecha_matriculacion,
                Color = vehiculoDto.Color,
                FotoUrl = vehiculoDto.FotoUrl,
                Id_cliente = vehiculoDto.Id_cliente,
                Fabricante = new Fabricante
                {
                    Nombre = vehiculoDto.Fabricante
                }
            };

            try
            {
                // Si se especificó un cliente, buscarlo en la base de datos
                if (vehiculoDto.Id_cliente.HasValue)
                {
                    var cliente = await _context.Clientes
                        .Include(c => c.Vehiculos) // Cargar vehículos asociados
                        .FirstOrDefaultAsync(c => c.Id_Cliente == vehiculoDto.Id_cliente.Value);

                    if (cliente == null)
                    {
                        return NotFound($"Cliente con ID {vehiculoDto.Id_cliente.Value} no encontrado.");
                    }

                    // Asociar el cliente al vehículo
                    vehiculo.Cliente = cliente;

                    // Agregar el vehículo a la lista de vehículos del cliente
                    cliente.Vehiculos.Add(vehiculo);
                }

                // Agregar el vehículo a la base de datos
                _context.Vehiculos.Add(vehiculo);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el vehículo: {ex.Message}");
            }
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateVehiculo(long id, [FromBody] VehiculoDto vehiculoDto)
        {
            if (id != vehiculoDto.Id_Vehiculo)
            {
                return BadRequest(new { Message = "El ID del vehículo no coincide." });
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound(new { Message = $"Vehículo con ID {id} no encontrado." });
            }

            // Mapear propiedades del DTO al modelo de entidad
            vehiculo.Matricula = vehiculoDto.Matricula;
            vehiculo.Modelo = vehiculoDto.Modelo;
            //vehiculo.Fabricante = vehiculoDto.Fabricante;
            vehiculo.Motorizacion = vehiculoDto.Motorizacion;
            vehiculo.Motor = vehiculoDto.Motor;
            vehiculo.Fecha_matriculacion = vehiculoDto.Fecha_matriculacion;
            vehiculo.Color = vehiculoDto.Color;
            vehiculo.FotoUrl = vehiculoDto.FotoUrl;

            try
            {
                _context.Vehiculos.Update(vehiculo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error al actualizar el vehículo: {ex.Message}" });
            }

            return NoContent();
        }

        // DELETE: api/vehiculo/{id}
        [HttpDelete("{id:long}")]
        public async Task<ActionResult> EliminarVehiculo(long id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound(new { Message = $"Vehiculo con ID {id} no encontrado." });
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();  
        }

        [HttpGet("Fabricantes")]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricantes()
        {
            try
            {
                var fabricantes = await _context.Fabricantes
                    .Select(f => new
                    {
                        f.Id,
                        f.Nombre
                    })
                    .ToListAsync();

                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener fabricantes: {ex.Message}");
                return StatusCode(500, "Error interno al obtener fabricantes.");
            }
        }

        [HttpGet("sinpropietario")]
        public async Task<ActionResult<IEnumerable<VehiculoDto>>> ObtenerVehiculosSinPropietario()
        {
            try
            {
                // Filtrar vehículos que no están asociados a un cliente
                var vehiculosSinPropietario = await _context.Vehiculos
                    .Where(v => v.Cliente == null) // Sin propietario
                    .Select(v => new VehiculoDto
                    {
                        Id_Vehiculo = v.Id,
                        Fabricante = v.Fabricante.Nombre,
                        Modelo = v.Modelo,
                        Matricula = v.Matricula,
                        Color = v.Color,
                        FotoUrl = v.FotoUrl
                    })
                    .ToListAsync();

                return Ok(vehiculosSinPropietario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener vehículos sin propietario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetVehiculosPorCliente(long clienteId)
        {
            try
            {
                var vehiculos = await _context.Vehiculos
                    .Include(v => v.Fabricante)
                    .Where(v => v.Id_cliente == clienteId)
                    .Select(v => new VehiculoDto
                    {
                        Id_Vehiculo = v.Id,
                        Matricula = v.Matricula,
                        Modelo = v.Modelo,
                        Fabricante = v.Fabricante.Nombre,
                        Color = v.Color
                    })
                    .ToListAsync();

                if (!vehiculos.Any())
                {
                    return NotFound("No se encontraron vehículos para este cliente.");
                }

                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener vehículos: {ex.Message}");
            }
        }
    }
}
