using System.ComponentModel.DataAnnotations;

namespace LeganesCustomsBlazor.Dtos;

public class ClienteDto
{
    public long Id_Cliente { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El primer apellido es obligatorio.")]
    public string Apellido1 { get; set; } = string.Empty;

    [Required(ErrorMessage = "El segundo apellido es obligatorio.")]
    public string Apellido2 { get; set; } = string.Empty;

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [RegularExpression(@"^\d{8}[A-Za-z]$", ErrorMessage = "El DNI debe tener 8 cifras y una letra.")]
    public string DNI { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Debe ser un email válido.")]
    public string? Email { get; set; }

    public string? Password { get; set; } = string.Empty;

    public string? ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 números.")]
    public string? Telefono { get; set; }
    
    public string? Direccion { get; set; }

    public List<VehiculoDto> Vehiculos { get; set; } = new List<VehiculoDto>();
    public List<CitaDto> Citas { get; set; } = new();
    public List<FacturaDto> Facturas { get; set; } = new();
}
