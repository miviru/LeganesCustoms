
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LeganesCustomsBlazor.Models;

public class Empleado : Persona
{
    public long Id_Empleado { get; set; } // Clave primaria autoincremental
    public int Sueldo { get; set; }

    [Required(ErrorMessage = "El puesto es obligatorio.")] 
    public string Puesto { get; set; } = string.Empty;    

    // Relacion 1:N con citas
    public List<Cita>? Citas { get; set; } = new List<Cita>();
}