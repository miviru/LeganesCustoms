
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Pieza 
{
    public long Id { get; set; } // _Clave primaria
    public string? Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public long Id_proveedor { get; set; } // Clave foránea
    public required Proveedor Proveedor { get; set; }
    public long Id_categoria { get; set; } // Clave foránea
    public required Categoria Categoria { get; set; }
    
   
}