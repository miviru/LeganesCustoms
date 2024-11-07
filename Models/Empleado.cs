
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Empleado : Persona
{
    public long Id_Empleado { get; set; } // Clave primaria
    public long Id_Persona { get; set; } // Clave foránea
    public required Persona Persona { get; set; }
    public int Sueldo { get; set; }
    public string? Puesto { get; set; }    

    // Relacion 1:N con citas
    public required List<Cita> Citas { get; set; }
}