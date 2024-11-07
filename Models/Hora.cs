
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Hora 
{
    public long Id { get; set; } // Clave primaria
    public int Horas { get; set; }
    public int Minutos { get; set; }

    public Hora(DateTime dateTime)
    {
        Horas = dateTime.Hour;
        Minutos = dateTime.Minute;
    }
}