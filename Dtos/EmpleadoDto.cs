namespace LeganesCustomsBlazor.Dtos;

public class EmpleadoDto
{
    public long Id_Empleado { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido1 { get; set; } = string.Empty;
    public string Apellido2 { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    public string Puesto { get; set; } = string.Empty; 
    public int Sueldo { get; set; } = 0; 

    public List<CitaDto> Citas { get; set; } = new();
    }
