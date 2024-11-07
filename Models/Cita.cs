
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeganesCustomsBlazor.Models;

public class Cita
{
    public long Id { get; set; } // Clave primaria

    [ForeignKey("Fecha")]
    public long Id_fecha { get; set; } // public date fecha { get; set; }
    public virtual required Fecha Fecha { get; set; }

    [ForeignKey("Hora")]
    public long Id_hora { get; set; } // public date hora { get; set; }
    public virtual required Hora Hora { get; set; }

    [ForeignKey("Vehiculo")]
    public long Id_vehiculo { get; set; } // Clave foránea
    public virtual required Vehiculo Vehiculo { get; set; }

    [ForeignKey("Empleado")]
    public long Id_empleado { get; set; } // Clave foránea
    public virtual required Empleado Empleado { get; set; }

    [ForeignKey("Cliente")]
    public long Id_cliente { get; set; } // Clave foránea
    public virtual required Cliente Cliente { get; set; }


    [ForeignKey("Servicio")]
    public long Id_servicio { get; set; } // Clave foránea
    public virtual required Servicio Servicio { get; set; }


    // Relacion 1:1 con factura
    [ForeignKey("Factura")]
    public long Id_factura { get; set; } // Clave foránea
    public virtual required Factura Factura { get; set; }
}