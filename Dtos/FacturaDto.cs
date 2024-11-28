namespace LeganesCustomsBlazor.Dtos;

public class FacturaDto
{
    public long Id { get; set; }
    public decimal Precio { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total => Precio - Descuento;
    public long ClienteId { get; set; }
    public required string ClienteNombre { get; set; }
    public string Apellido1 { get; set; } = string.Empty;
    public string Apellido2 { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Direccion { get; set; } = string.Empty;

    // Vehículo asociado (1:1)
    public long VehiculoId { get; set; }
    public VehiculoDto? Vehiculo { get; set; } = new();

    // Servicios asociados
    public List<ServicioDto> Servicios { get; set; } = new();
    // Piezas utilizadas
    public List<PiezaDto> Piezas { get; set; } = new();

    // Cita relacionada
    public CitaDto? Cita { get; set; } // Permitir nulo si no está asignada

}

public class PiezaDto
{
    public string? Nombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

public class ServicioDto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}

