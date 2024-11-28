namespace LeganesCustomsBlazor.Dtos;

public class ClienteDto
{
    public long Id_Cliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido1 { get; set; } = string.Empty;
    public string Apellido2 { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    public List<VehiculoDto> Vehiculos { get; set; } = new();
    public List<CitaDto> Citas { get; set; } = new();
    public List<FacturaDto> Facturas { get; set; } = new();
}