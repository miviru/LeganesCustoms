namespace LeganesCustomsBlazor.Dtos;

public class ClienteDto
{
    public long Id_Cliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido1 { get; set; } = string.Empty;
    public string Apellido2 { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }

    public List<VehiculoDto> Vehiculos { get; set; } = new List<VehiculoDto>();
    public List<CitaDto> Citas { get; set; } = new();
    public List<FacturaDto> Facturas { get; set; } = new();
}
