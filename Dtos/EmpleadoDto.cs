using System.ComponentModel.DataAnnotations;

namespace LeganesCustomsBlazor.Dtos;

public class EmpleadoDto
{
    public long Id_Empleado { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    public string Apellido1 { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    public string Apellido2 { get; set; } = string.Empty;

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [RegularExpression(@"^\d{8}[A-Za-z]$", ErrorMessage = "El DNI debe contener 8 números seguidos de una letra.")]
    public string DNI { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Debe ser un email válido.")]
    public string Email { get; set; } = string.Empty;

    [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe contener exactamente 9 dígitos.")]
    public string Telefono { get; set; } = string.Empty;

    public string Direccion { get; set; } = string.Empty;

    public string? Password { get; set; } = string.Empty;

    public string? ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "El puesto es obligatorio.")]
    public string Puesto { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "El sueldo debe ser un valor positivo.")]
    public int Sueldo { get; set; } = 0; 

    public List<CitaDto> Citas { get; set; } = new();
    }
