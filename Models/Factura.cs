
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Factura 
{
    public long Id { get; set; } // Clave primaria
    public long Id_cliente { get; set; } // Clave foránea
    public required Cliente Cliente { get; set; }
    public long Id_cita { get; set; } // Clave foránea
    public Cita? Cita { get; set; }
    public decimal Precio { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total { get; set; }

    // Relación 1:1 con Pago
    public Pago? Pago { get; set; }

    // Relación N:M con Servicios
    public virtual ICollection<FacturaServicio> FacturaServicios { get; set; } = new List<FacturaServicio>();

    // Relación N:M con Piezas a través de FacturaPieza
    public virtual ICollection<FacturaPieza> FacturaPiezas { get; set; } = new List<FacturaPieza>();

    // Clave foránea para Vehículo
    public long VehiculoId { get; set; }
    public Vehiculo Vehiculo { get; set; } = null!; // Relación 1:N con Vehículo
}