
using LeganesCustomsBlazor.Models;
using LeganesCustomsBlazor.Dtos;
using System.Text.Json;

public class ClienteService
{
    private readonly HttpClient _http;

    public ClienteService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        // Configurar manualmente si está vacía
        if (_http.BaseAddress == null)
        {
            _http.BaseAddress = new Uri("http://localhost:5183/");
            Console.WriteLine($"BaseAddress configurada manualmente en ClienteService: {_http.BaseAddress}");
        }
        else
        {
            Console.WriteLine($"BaseAddress configurada en ClienteService: {_http.BaseAddress}");
        }
    }

   public async Task CrearClienteAsync(Cliente cliente)
    {
        try
        {
            // Mapeo manual de Cliente a ClienteDto
            var clienteDto = new ClienteDto
            {
                Id_Cliente = cliente.Id_Cliente,
                Nombre = cliente.Nombre,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                DNI = cliente.DNI,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion ?? string.Empty,
                Vehiculos = cliente.Vehiculos.Select(v => new VehiculoDto
                {
                    // Mapear propiedades de Vehiculo aquí
                }).ToList(),
                Citas = cliente.Citas?.Select(c => new CitaDto
                {
                    Id = c.Id,
                    Fecha = new DateTime(c.Fecha.Año, c.Fecha.Mes, c.Fecha.Dia),
                    Hora = $"{c.Hora.Horas:D2}:{c.Hora.Minutos:D2}",
                    ClienteNombre = c.Cliente.Nombre,
                    EmpleadoNombre = c.Empleado.Nombre,
                    VehiculoDetalles = $"{c.Vehiculo.Fabricante} {c.Vehiculo.Modelo}"
                }).ToList() ?? new List<CitaDto>(),
                Facturas = cliente.Facturas.Select(f => new FacturaDto
                {
                    ClienteNombre = f.Cliente.Nombre,
                }).ToList()
            };

            // Enviar clienteDto al backend
            var response = await _http.PostAsJsonAsync("api/cliente", clienteDto);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear cliente: {error}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al crear cliente: {ex.Message}");
            throw;
        }
    }

    public async Task<ClienteDto> GetClienteByIdAsync(long id)
    {
        try
        {
            // Realiza la solicitud al endpoint de la API
            var response = await _http.GetAsync($"api/cliente/{id}");

            // Verifica si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta y deserializa a ClienteDto
                var cliente = await response.Content.ReadFromJsonAsync<ClienteDto>();

                // Verifica si se recibió un cliente válido
                if (cliente == null)
                {
                    Console.WriteLine("El cliente no fue encontrado.");
                    throw new Exception("Cliente no encontrado.");
                }

                return cliente;
            }
            else
            {
                // Maneja el error si el código de estado no es exitoso
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al obtener cliente: {errorContent}");
                throw new Exception($"Error al obtener cliente: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            // Maneja errores inesperados
            Console.WriteLine($"Error inesperado al obtener cliente: {ex.Message}");
            throw;
        }
    }

    public async Task<List<ClienteDto>> GetClientesAsync()
    {
        try
        {
            Console.WriteLine($"BaseAddress: {_http.BaseAddress}"); // Verifica la dirección base
            
            var response = await _http.GetAsync("api/cliente");

            if (response.IsSuccessStatusCode)
            {
                var clientes = await response.Content.ReadFromJsonAsync<List<ClienteDto>>();
                return clientes ?? new List<ClienteDto>();
            }
            else
            {
                Console.WriteLine($"Error: Código de estado {response.StatusCode}");
                return new List<ClienteDto>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            return new List<ClienteDto>();
        }
    }

    public async Task UpdateClienteAsync(ClienteDto clienteDto)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"api/cliente/{clienteDto.Id_Cliente}", clienteDto);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al actualizar cliente: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al actualizar cliente: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteClienteAsync(long id)
    {
        Console.WriteLine($"Enviando solicitud DELETE para el cliente con ID {id}...");

        var response = await _http.DeleteAsync($"api/cliente/{id}");
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error en la solicitud DELETE: {response.StatusCode}, {error}");
            throw new Exception($"Error al eliminar el cliente: {error}");
        }

        Console.WriteLine($"Cliente con ID {id} eliminado exitosamente.");
    }

    public async Task<List<ClienteDto>> ObtenerClientesAsync()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<List<ClienteDto>>("api/cliente");
            return response ?? new List<ClienteDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener clientes: {ex.Message}");
            throw;
        }
    }

}
