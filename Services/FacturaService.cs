using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;

namespace LeganesCustomsBlazor.Services;

public class FacturaService
{
    private readonly AppDbContext _context;

    public FacturaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FacturaDto>> GetAllFacturasAsync(int page = 1, int pageSize = 10)
    {
        return await _context.Facturas
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(f => new FacturaDto
            {
                Id = f.Id,
                Precio = f.Precio,
                Descuento = f.Descuento,
                ClienteId = f.Cliente.Id,
                ClienteNombre = f.Cliente.Nombre
            })
            .ToListAsync();
    }

    public async Task<FacturaDto?> GetFacturaByIdAsync(long id)
    {
        try
        {
            return await _context.Facturas
                .AsNoTracking()
                .Where(f => f.Id == id)
                .Select(f => new FacturaDto
                {
                    Id = f.Id,
                    Precio = f.Precio,
                    Descuento = f.Descuento,
                    ClienteId = f.Cliente.Id,
                    ClienteNombre = f.Cliente.Nombre,
                    Apellido1 = f.Cliente.Apellido1,
                    Apellido2 = f.Cliente.Apellido2,
                    DNI = f.Cliente.DNI,
                    Email = f.Cliente.Email,
                    Direccion = f.Cliente.Direccion,
                    Servicios = f.FacturaServicios.Select(fs => new ServicioDto
                    {
                        Id = fs.Servicio.Id,
                        Nombre = fs.Servicio.Nombre ?? "Sin nombre",
                        Precio = fs.Servicio.Precio
                    }).ToList(),
                    Vehiculo = f.Vehiculo == null ? null : new VehiculoDto
                    {
                        Id_Vehiculo = f.Vehiculo.Id,
                        Fabricante = f.Vehiculo.Fabricante.Nombre,
                        Modelo = f.Vehiculo.Modelo,
                        Matricula = f.Vehiculo.Matricula,
                        FotoUrl = f.Vehiculo.FotoUrl 
                    },
                    Piezas = f.FacturaPiezas.Select(fp => new PiezaDto
                    {
                        Nombre = fp.Pieza.Nombre,
                        Cantidad = fp.Pieza.Cantidad,
                        PrecioUnitario = fp.Pieza.Precio
                    }).ToList(),
                    Cita = f.Cita == null ? null : new CitaDto
                    {
                        Id = f.Cita.Id,
                        Fecha = f.Cita.Fecha.ToDateTime(),
                        Hora = f.Cita.Hora.HoraCompleta.ToString(@"hh\:mm")
                    }
                })
                .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener factura: {ex.Message}");
            return null;
        }
    }

    public async Task<FacturaDto?> CreateFacturaAsync(Factura factura)
    {
        try
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            return new FacturaDto
            {
                Id = factura.Id,
                Precio = factura.Precio,
                Descuento = factura.Descuento,
                ClienteId = factura.Cliente.Id,
                ClienteNombre = factura.Cliente.Nombre
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear factura: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> UpdateFacturaAsync(long id, FacturaDto facturaDto)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null) return false;

        try
        {
            factura.Precio = facturaDto.Precio; // Asegúrate de que Precio sea decimal en el modelo
            factura.Descuento = facturaDto.Descuento;
            factura.Total = facturaDto.Total;

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar factura: {ex.Message}");
            return false;
        }
    }


    public async Task<bool> DeleteFacturaAsync(long id)
    {
        var factura = await _context.Facturas
            .Include(f => f.Vehiculo) // Relación 1:N con Vehiculo
            .Include(f => f.FacturaPiezas) // Relación N:M con Piezas
                .ThenInclude(fp => fp.Pieza) // Incluye las piezas a través de FacturaPieza
            .FirstOrDefaultAsync(f => f.Id == id);

        if (factura == null) return false;

        try
        {
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar factura: {ex.Message}");
            return false;
        }
    }

}
