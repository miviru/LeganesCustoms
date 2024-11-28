
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Pago 
{
    public long Id { get; set; } // Clave primaria
    public MetodoPago Metodo_Pago { get; set; }
    public decimal Importe { get; set; }
   
    // Relación 1:1 con Factura
    public virtual Factura? Factura { get; set; }
}