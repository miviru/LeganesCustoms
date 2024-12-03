using Microsoft.AspNetCore.Mvc;
using LeganesCustomsBlazor.Services;
using LeganesCustomsBlazor.Dtos;

[ApiController]
[Route("api/[controller]")]
public class CitasController : ControllerBase
{
    private readonly CitaService _citaService; // Cambio aquí

    public CitasController(CitaService citaService) // Cambio aquí
    {
        _citaService = citaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCitas()
    {
        var citas = await _citaService.GetAllCitasAsync();
        return Ok(citas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCitaById(long id)
    {
        var cita = await _citaService.GetCitaByIdAsync(id);
        if (cita == null) return NotFound();
        return Ok(cita);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCita([FromBody] CitaDto citaDto)
    {
        var createdCita = await _citaService.CreateCitaAsync(citaDto);
        return CreatedAtAction(nameof(GetCitaById), new { id = createdCita.Id }, createdCita);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCita(long id, [FromBody] CitaDto citaDto)
    {
        var updated = await _citaService.UpdateCitaAsync(id, citaDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCita(long id)
    {
        var deleted = await _citaService.DeleteCitaAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
