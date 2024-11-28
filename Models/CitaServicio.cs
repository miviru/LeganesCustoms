using System;

namespace LeganesCustomsBlazor.Models;

public class CitaServicio
{
    public long Id_cita { get; set; } // Clave foránea hacia Cita
    public virtual required Cita Cita { get; set; } // Propiedad de navegación a Cita

    public long Id_servicio { get; set; } // Clave foránea hacia Servicio
    public virtual required Servicio Servicio { get; set; } // Propiedad de navegación a Servicio
}
