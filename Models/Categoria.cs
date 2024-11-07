
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Categoria 
{
    public long Id { get; set; } // Clave primaria
    public string? Nombre { get; set; } // Enum?

    // Relacion 1:N con piezas
    public required List<Pieza> Piezas { get; set; }

}