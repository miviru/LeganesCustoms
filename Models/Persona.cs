
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Persona 
{
    public long Id { get; set; } // Clave primaria

    public string? Nombre { get; set; } 
    public string? Apellido1 { get; set; }
    public string? Apellido2 { get; set; } 
    public string? DNI { get; set; } 

    public string? Email { get; set; } 
    public string? Telefono { get; set; } 
    public string? Direccion { get; set; } 
}