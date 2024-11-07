
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Proveedor 
{
    public long Id { get; set; } // Clave primaria
    public string? Nombre { get; set; }
    public string? CIF { get; set; }

    // Relacion 1:N con piezas
    public required List<Pieza> Piezas { get; set; }
   
}