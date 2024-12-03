using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;

namespace LeganesCustomsBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacturaController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/Factura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> GetFacturas()
        {
            if (_context.Facturas == null)
            {
                return Problem("Facturas no está disponible en el contexto.");
            }

            try
            {
                var facturas = await _context.Facturas
                    .Include(f => f.Cliente) // Include related data
                    .Include(f => f.Cita)
                    .Include(f => f.FacturaServicios)
                    .Include(f => f.FacturaPiezas)
                    .ToListAsync();

                if (!facturas.Any())
                {
                    return Ok(new List<FacturaDto>()); // Return an empty list if none are found
                }

                // Transform to DTO
                var facturasDto = facturas.Select(f => new FacturaDto
                {
                    Id = f.Id,
                    Precio = f.Precio,
                    Descuento = f.Descuento,
                    ClienteNombre = f.Cliente.Nombre
                    
                }).ToList();

                return Ok(facturasDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener facturas: {ex.Message}");
                return Problem("Ocurrió un error al intentar obtener las facturas.");
            }
        }

        // GET: api/Factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDto>> GetFactura(long id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Facturas no está disponible en el contexto.");
            }

            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Cita)
                .Include(f => f.FacturaServicios)
                .Include(f => f.FacturaPiezas)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (factura == null)
            {
                return NotFound("Factura no encontrada.");
            }

            // Map to DTO
            var facturaDto = new FacturaDto
            {
                Id = factura.Id,
                Precio = factura.Precio,
                Descuento = factura.Descuento,
                ClienteNombre = factura.Cliente.Nombre
            };

            return Ok(facturaDto);
        }

        // POST: api/Factura
        [HttpPost]
        public async Task<ActionResult<FacturaDto>> CreateFactura(FacturaDto facturaDto)
        {
            var cliente = await _context.Clientes.FindAsync(facturaDto.ClienteId); // Assuming ClienteId is in DTO
            if (cliente == null)
            {
                return NotFound("Cliente asociado no encontrado.");
            }
            if (facturaDto == null)
            {
                return BadRequest("La factura no puede ser nula.");
            }

            // Map DTO to model
            var factura = new Factura
            {
                Precio = (int)facturaDto.Precio,
                Descuento = (int)facturaDto.Descuento,
                Total = facturaDto.Total,
                Cliente = cliente
            };

            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            facturaDto.Id = factura.Id;

            return CreatedAtAction(nameof(GetFactura), new { id = factura.Id }, facturaDto);
        }

        // PUT: api/Factura/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactura(long id, FacturaDto facturaDto)
        {
            if (id != facturaDto.Id)
            {
                return BadRequest("El ID de la factura no coincide.");
            }

            if (_context.Facturas == null)
            {
                return Problem("Facturas no está disponible en el contexto.");
            }

            var facturaExistente = await _context.Facturas.FindAsync(id);
            if (facturaExistente == null)
            {
                return NotFound("Factura no encontrada.");
            }

            // Update fields
            facturaExistente.Precio = (int)facturaDto.Precio;
            facturaExistente.Descuento = (int)facturaDto.Descuento;
            facturaExistente.Total = facturaDto.Total;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FacturaExists(id))
                {
                    return NotFound("La factura no existe.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(long id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Facturas no está disponible en el contexto.");
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound("Factura no encontrada.");
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> FacturaExists(long id)
        {
            if (_context.Facturas == null)
            {
                throw new InvalidOperationException("Facturas no está configurado en el contexto.");
            }

            return await _context.Facturas.AnyAsync(f => f.Id == id);
        }
    }
}
