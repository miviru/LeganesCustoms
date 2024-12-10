using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;
using System.Text.Json;
using LeganesCustomsBlazor.Services;
using System.Net;
using System.Text;
using System.Net.Http;

public class EmpleadoService : IEmpleadoService
{
    private readonly HttpClient _http;

    public EmpleadoService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        // Configurar manualmente si está vacía
        if (_http.BaseAddress == null)
        {
            _http.BaseAddress = new Uri("http://localhost:5183/");
            Console.WriteLine($"BaseAddress configurada manualmente en EmpleadoService: {_http.BaseAddress}");
        }
        else
        {
            Console.WriteLine($"BaseAddress configurada en EmpleadoService: {_http.BaseAddress}");
        }
    }

    public async Task CrearEmpleadoAsync(EmpleadoDto empleadoDto)
    {
        try
        {
            var token = await _http.GetStringAsync("/antiforgery/token"); // Endpoint para obtener el token

            // Crear solicitud con encabezado antiforgery
            var request = new HttpRequestMessage(HttpMethod.Post, "api/empleado")
            {
                Content = JsonContent.Create(empleadoDto)
            };

            request.Headers.Add("RequestVerificationToken", token);

            var response = await _http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear empleado: {error}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al crear empleado: {ex.Message}");
            throw;
        }
    }

    public async Task<EmpleadoDto> GetEmpleadoByIdAsync(long id)
    {
        try
        {
            var response = await _http.GetAsync($"api/empleado/{id}");

            if (response.IsSuccessStatusCode)
            {
                var empleado = await response.Content.ReadFromJsonAsync<EmpleadoDto>();
                return empleado ?? throw new Exception("Empleado no encontrado.");
            }
            else
            {            
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener empleado: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            throw;
        }
    }
        public async Task<List<EmpleadoDto>> GetEmpleadosAsync()
        {
            try
            {
                Console.WriteLine($"BaseAddress: {_http.BaseAddress}"); // Verifica la dirección base

                // Llama al endpoint de la API
                var response = await _http.GetAsync("api/empleado");

                // Verifica si la respuesta es exitosa
                if (response.IsSuccessStatusCode)
                {
                    var empleados = await response.Content.ReadFromJsonAsync<List<EmpleadoDto>>();

                    if (empleados == null)
                    {
                        Console.WriteLine("La respuesta JSON es nula o no contiene datos.");
                        return new List<EmpleadoDto>();
                    }

                    return empleados;
                }
                else
                {
                    Console.WriteLine($"Error: Código de estado {response.StatusCode}, contenido: {await response.Content.ReadAsStringAsync()}");
                    return new List<EmpleadoDto>();
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error HTTP: {httpEx.Message}");
                return new List<EmpleadoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return new List<EmpleadoDto>();
            }
        }

    public async Task UpdateEmpleadoAsync(EmpleadoDto empleadoDto)
    {
        try
        {
            // Serializa el objeto empleadoDto a JSON
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(empleadoDto),
                Encoding.UTF8,
                "application/json" // Tipo MIME correcto para JSON
            );

            // Realiza la solicitud PUT con el contenido JSON
            var response = await _http.PutAsync(
                $"api/empleado/{empleadoDto.Id_Empleado}",
                jsonContent
            );

            // Verifica si la respuesta fue exitosa
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar empleado: {response.StatusCode}, {errorContent}");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones y logging
            Console.WriteLine($"Error inesperado al actualizar empleado: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteEmpleadoAsync(long id)
    {
        Console.WriteLine($"Enviando solicitud DELETE para el empleado con ID {id}...");

        var response = await _http.DeleteAsync($"api/empleado/{id}");
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error en la solicitud DELETE: {response.StatusCode}, {error}");
            throw new Exception($"Error al eliminar empleado: {error}");
        }

        Console.WriteLine($"Empleado con ID {id} eliminado exitosamente.");
    }

    public async Task<EmpleadoDto?> GetEmpleadoLogueadoAsync()
    {
        var response = await _http.GetAsync("api/empleado/logueado");

        if (response.IsSuccessStatusCode)
        {
            var empleado = await response.Content.ReadFromJsonAsync<EmpleadoDto>();
            return empleado;
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error al obtener empleado logueado: {errorContent}");
            return null; // Devuelve null si no hay empleado asociado
        }

        throw new Exception($"Error al obtener empleado logueado: {response.StatusCode}");
    }

}
