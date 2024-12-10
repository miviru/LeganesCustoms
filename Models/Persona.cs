using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace LeganesCustomsBlazor.Models;

public class Persona 
{
    [Key]
    public long Id { get; set; } // Clave primaria

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El primer apellido es obligatorio.")]
    public string Apellido1 { get; set; } = string.Empty;

    [Required(ErrorMessage = "El segundo apellido es obligatorio.")]
    public string Apellido2 { get; set; } = string.Empty; 

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    public string DNI { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El email es obligatorio.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El telefono es obligatorio.")] 
    public string Telefono { get; set; } = string.Empty;
    
    public string? Direccion { get; set; }

    // Relación con IdentityUser
    public string? IdentityUserId { get; set; }
    public IdentityUser? IdentityUser { get; set; }

}