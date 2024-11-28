
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Pieza 
{
    public long Id { get; set; } // _Clave primaria
    public string? Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    // Relación con Proveedores a través de PiezaProveedor
    public virtual ICollection<PiezaProveedor> PiezaProveedores { get; set; } = new List<PiezaProveedor>();
  
    // Relación con Categoría (1:N)
    public long Id_categoria { get; set; } // Clave foránea
    public required Categoria Categoria { get; set; }

    // Relación con Citas (N:M)
    public virtual ICollection<CitaPieza> CitaPiezas { get; set; } = new List<CitaPieza>();

    // Relación N:M con Factura a través de FacturaPieza
    public virtual ICollection<FacturaPieza> FacturaPiezas { get; set; } = new List<FacturaPieza>();
}