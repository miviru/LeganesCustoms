
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Fecha
{
    public long Id { get; set; } // Clave primaria
    public int Dia { get; set; }
    public int Mes { get; set; }
    public int Año { get; set; }

    // Propiedad de navegación para la relación 1:N con Cita
    public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();

    public Fecha(DateTime dateTime)
    {
        Dia = dateTime.Day;
        Mes = dateTime.Month;
        Año = dateTime.Year;
    }

    // Constructor sin parámetros (necesario para EF Core)
    public Fecha()
    {
    }

    // Propiedad calculada para obtener un DateTime
    public DateTime ToDateTime()
    {
        return new DateTime(Año, Mes, Dia);
    }
}