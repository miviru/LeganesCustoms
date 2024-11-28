using System;

namespace LeganesCustomsBlazor.Models;

public class CitaPieza
{
    public long Id_cita { get; set; } // Clave foránea a Cita
    public virtual required Cita Cita { get; set; } // Propiedad de navegación a Cita

    public long Id_pieza { get; set; } // Clave foránea a Pieza
    public virtual required Pieza Pieza { get; set; } // Propiedad de navegación a Pieza
}
