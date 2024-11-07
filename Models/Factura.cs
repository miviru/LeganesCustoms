
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Factura 
{
    public long Id { get; set; } // Clave primaria
    public long Id_cliete { get; set; } // Clave foránea
    public required Cliente Cliente { get; set; }
    public long Id_cita { get; set; } // Clave foránea
    public required Cita Cita { get; set; }
    public int Precio { get; set; }
    public int Descuento { get; set; }
    public long Id_servicio { get; set; } // Clave foránea
    public required Servicio Servicio { get; set; }
    public long Id_pago { get; set; } // Clave foránea
    public required Pago Pago { get; set; }
}