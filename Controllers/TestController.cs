using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Dtos;
using Newtonsoft.Json;

[ApiController]
[Route("api/test123")]
public class TestController : ControllerBase
{
    private readonly AppDbContext _context;

    public TestController(AppDbContext context)
    {
        _context = context;
    }

    [HttpDelete("{id}")]
    [IgnoreAntiforgeryToken] // Ignora la validación antiforgery

public async Task<IActionResult> TestDelete(long id)
{
    Console.WriteLine($"Entró al método TestDelete con ID: {id}");

    try
    {
        Console.WriteLine("Iniciando búsqueda del empleado en la base de datos...");
        Console.WriteLine($"Contexto de la base de datos: {_context != null}");

        // Busca el empleado en la base de datos
        var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id_Empleado == id);
        if (empleado == null)
        {
            Console.WriteLine($"Empleado con ID {id} no encontrado.");
            return NotFound($"Empleado con ID {id} no existe.");
        }

        Console.WriteLine($"Empleado encontrado: {empleado.Id_Empleado}");

        // Elimina el empleado
        _context.Empleados.Remove(empleado);
        await _context.SaveChangesAsync();

        Console.WriteLine($"Empleado con ID {id} eliminado correctamente.");
        return NoContent(); // Código 204 si la eliminación es exitosa
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar el empleado: {ex.Message}");
        return StatusCode(500, "Error interno al eliminar el empleado.");
    }
}


}

