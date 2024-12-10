using System.Threading.Tasks;
using LeganesCustomsBlazor.Models; 
using LeganesCustomsBlazor.Dtos;

namespace LeganesCustomsBlazor.Services
{
    public interface IEmpleadoService
    {
        Task<EmpleadoDto> GetEmpleadoByIdAsync(long id);
        Task<EmpleadoDto> GetEmpleadoLogueadoAsync();
        Task CrearEmpleadoAsync(EmpleadoDto empleadoDto);
        Task<List<EmpleadoDto>> GetEmpleadosAsync();
        Task UpdateEmpleadoAsync(EmpleadoDto empleadoDto);
        Task DeleteEmpleadoAsync(long id);
    }
}
