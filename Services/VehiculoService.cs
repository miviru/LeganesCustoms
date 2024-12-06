using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;
using Newtonsoft.Json;

public class VehiculoService
{
    private readonly HttpClient _http;

    public VehiculoService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));

        // Configurar manualmente si está vacía
        if (_http.BaseAddress == null)
        {
            _http.BaseAddress = new Uri("http://localhost:5183/");
            Console.WriteLine($"BaseAddress configurada manualmente en VehiculoService: {_http.BaseAddress}");
        }
        else
        {
            Console.WriteLine($"BaseAddress configurada en VehiculoService: {_http.BaseAddress}");
        }
    }

    public async Task<List<Cliente>> ObtenerClientesAsync()
    {
        var response = await _http.GetFromJsonAsync<List<Cliente>>("api/clientes");
        if (response == null)
        {
            throw new Exception("No se pudo obtener la lista de clientes.");
        }
        return response;
    }

    public async Task CrearVehiculoAsync(VehiculoDto vehiculoDto)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/vehiculo", vehiculoDto);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el vehículo: {error}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al crear el vehículo: {ex.Message}");
            throw;
        }
    }

    public async Task<VehiculoDto?> GetVehiculoByIdAsync(long id)
    {
        try
        {
            var response = await _http.GetAsync($"api/vehiculo/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<VehiculoDto>();
            }
            else
            {
                throw new Exception($"Error al obtener vehiculo: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            throw;
        }
    }

    public async Task<List<VehiculoDto>> GetVehiculosAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/vehiculo");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<VehiculoDto>>() ?? new List<VehiculoDto>();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener vehículos: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            return new List<VehiculoDto>();
        }
    }

    public async Task UpdateVehiculoAsync(VehiculoDto vehiculoDto)
    {
        try
        {
            // Realiza la llamada HTTP pasando el DTO
            var response = await _http.PutAsJsonAsync($"api/vehiculo/{vehiculoDto.Id_Vehiculo}", vehiculoDto);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al actualizar vehiculo: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al actualizar vehiculo: {ex.Message}");
            throw;
        }
    }


    public async Task DeleteVehiculoAsync(long id)
    {
        try
        {
            var response = await _http.DeleteAsync($"api/vehiculo/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar vehiculo: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al eliminar vehiculo: {ex.Message}");
            throw;
        }
    }

    public async Task<List<Fabricante>> ObtenerFabricantesAsync()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<List<Fabricante>>("api/vehiculo/Fabricantes");
            return response ?? new List<Fabricante>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener fabricantes: {ex.Message}");
            return new List<Fabricante>();
        }
    }

}
