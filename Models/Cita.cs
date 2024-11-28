
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeganesCustomsBlazor.Models;

public class Cita
{
    public long Id { get; set; } // Clave primaria

    public long Id_fecha { get; set; } // public date fecha { get; set; }
    public virtual required Fecha Fecha { get; set; }

    public long Id_hora { get; set; } // public date hora { get; set; }
    public virtual required Hora Hora { get; set; }

    public long Id_vehiculo { get; set; } // Clave foránea
    public virtual required Vehiculo Vehiculo { get; set; }

    public long Id_empleado { get; set; } // Clave foránea
    public virtual required Empleado Empleado { get; set; }

    public long Id_cliente { get; set; } // Clave foránea
    public virtual required Cliente Cliente { get; set; }

    // Relación N:M con Servicio
    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    // Relacion 1:1 con factura
    public long Id_factura { get; set; } // Clave foránea
    public virtual Factura? Factura { get; set; }

    // Relación N:M con Pieza
    public virtual ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();

    public virtual ICollection<CitaPieza> CitaPiezas { get; set; } = new List<CitaPieza>();

    public virtual ICollection<CitaServicio> CitaServicios { get; set; } = new List<CitaServicio>();
}
