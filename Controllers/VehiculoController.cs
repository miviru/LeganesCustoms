using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;

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
    public async Task<ActionResult<IEnumerable<VehiculoDto>>> GetVehiculos()
    {
        var vehiculos = await _context.Vehiculos
            .Include(v => v.Fabricante)
            .Select(v => new VehiculoDto
            {
                Id_Vehiculo = v.Id,
                Matricula = v.Matricula,
                Modelo = v.Modelo,
            })
            .ToListAsync();

        return Ok(vehiculos);
    }

    // GET: api/vehiculo/{id}
    [HttpGet("{id:long}")]
    public async Task<ActionResult<VehiculoDto>> GetVehiculo(long id)
    {
        var vehiculo = await _context.Vehiculos
            .Include(v => v.Fabricante)
            .Include(v => v.Citas)
            .ThenInclude(c => c.Fecha)
            .Include(v => v.Cliente)
            .Where(v => v.Id == id)
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
                FotoUrl = v.FotoUrl,
                Citas = v.Citas.Select(c => new CitaDto
                {
                    Fecha = c.Fecha.ToDateTime()
                }).ToList(),
                Cliente = v.Cliente == null ? null : new ClienteDto
                {
                    Nombre = v.Cliente.Nombre,
                    Apellido1 = v.Cliente.Apellido1,
                    Apellido2 = v.Cliente.Apellido2,
                    Email = v.Cliente.Email,
                    Telefono = v.Cliente.Telefono
                }
            })

            .FirstOrDefaultAsync();

        if (vehiculo == null)
        {
            return NotFound(new { Message = $"Vehiculo con ID {id} no encontrado." });
        }

        return Ok(vehiculo);
    }

    // POST: api/vehiculo
    [HttpPost]
    public async Task<ActionResult> CrearVehiculo([FromBody] Vehiculo vehiculo)
    {
        try
        {
            if (vehiculo == null)
            {
                return BadRequest(new { Message = "El vehiculo es inválido." });
            }

            await _context.Vehiculos.AddAsync(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = $"Error al crear el vehiculo: {ex.Message}" });
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
}
