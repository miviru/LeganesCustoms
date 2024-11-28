
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Proveedor 
{
    public long Id { get; set; } // Clave primaria
    public string? Nombre { get; set; }
    public string? CIF { get; set; }

    // Relación con Piezas a través de PiezaProveedor
    public virtual ICollection<PiezaProveedor> PiezaProveedores { get; set; } = new List<PiezaProveedor>();   
}