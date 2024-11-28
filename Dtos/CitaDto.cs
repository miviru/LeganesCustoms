namespace LeganesCustomsBlazor.Dtos;

public class CitaDto
{
    public long Id { get; set; }
    public DateTime Fecha { get; set; } 
    public string Hora { get; set; } = string.Empty; 
    public string ClienteNombre { get; set; } = string.Empty;
    public string ClienteApellido { get; set; } = string.Empty;
    public string? ClienteApellido2 { get; set; }
    public string? DNI { get; set; }
    public string EmpleadoNombre { get; set; } = string.Empty;
    public string VehiculoDetalles { get; set; } = string.Empty;
    public long IdVehiculo { get; set; }
    public IEnumerable<string> Servicios { get; set; } = new List<string>();
    public IEnumerable<string> Piezas { get; set; } = new List<string>();
    public string? FacturaNumero { get; set; } 
    public decimal FacturaTotal { get; set; }
}
