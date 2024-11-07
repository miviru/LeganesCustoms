
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Servicio 
{
    public long Id { get; set; } // Clave primaria
    public string? Nombre { get; set; }
    public int Precio { get; set; }
    public decimal Duracion { get; set; }

    // Relacion 1:N con citas
    public required List<Cita> Citas { get; set; }
        
}