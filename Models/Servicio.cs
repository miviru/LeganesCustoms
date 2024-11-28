
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Servicio 
{
    public long Id { get; set; } // Clave primaria
    public string? Nombre { get; set; }
    public int Precio { get; set; }
    public decimal Duracion { get; set; }

    // Relacion N:M con citas
    public virtual ICollection<CitaServicio> CitaServicios { get; set; } = new List<CitaServicio>();

    // Relación N:M con Facturas
    public virtual ICollection<FacturaServicio> FacturaServicios { get; set; } = new List<FacturaServicio>();
}