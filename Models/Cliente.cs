
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Cliente : Persona
{
    public long Id_Cliente { get; set; } // Clave primaria
    public long Id_Persona { get; set; } // Clave foránea
    public required Persona Persona { get; set; }

    // Relacion 1:N con vehiculos
    public required List<Vehiculo> Vehiculos { get; set; }

    // Relacion 1:N con citas
    public List<Cita>? Citas { get; set; }
}