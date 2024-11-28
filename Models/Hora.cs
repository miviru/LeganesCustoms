
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Hora 
{
    public long Id { get; set; } // Clave primaria
    public int Horas { get; set; }
    public int Minutos { get; set; }

    // Propiedad de navegación para la relación 1:1 con Cita
    public virtual Cita? Cita { get; set; }

    // Constructor que recibe un DateTime y una Cita
    public Hora(DateTime dateTime)
    {
        Horas = dateTime.Hour;
        Minutos = dateTime.Minute;
    }

    // Constructor sin parámetros (necesario para EF Core)
    public Hora()
    {
    }
    
    // Propiedad calculada para obtener la hora completa como TimeSpan
    public TimeSpan HoraCompleta => new TimeSpan(Horas, Minutos, 0);

}