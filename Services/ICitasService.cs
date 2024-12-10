using System.Collections.Generic;
using System.Threading.Tasks;
using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;

namespace LeganesCustomsBlazor.Services
{
    public interface ICitasService
    {
        Task<IEnumerable<CitaDto>> GetAllCitasAsync();
        Task<CitaDto?> GetCitaByIdAsync(long id);
        Task<CitaDto> CreateCitaAsync(CitaDto citaDto);
        Task<bool> UpdateCitaAsync(long id, CitaDto citaDto);
        Task<bool> DeleteCitaAsync(long id);
        Task<List<Cita>> GetCitasPorEmpleadoAsync(long empleadoId);
        Task<List<Cita>> GetCitasPorClienteIdAsync(long clienteId);
    }
}
