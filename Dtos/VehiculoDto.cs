namespace LeganesCustomsBlazor.Dtos;

public class VehiculoDto
{
    public long Id_Vehiculo { get; set; }
    public string Matricula { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public string? Motorizacion { get; set; } 
    public string? Motor { get; set; }
    public DateTime Fecha_matriculacion { get; set; }
    public string? Color { get; set;}
    public string? FotoUrl { get; set; }
    public List<CitaDto>? Citas { get; set; }
    public ClienteDto? Cliente { get; set; } 

}
