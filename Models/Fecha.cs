
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Fecha
{
    public long Id { get; set; } // Clave primaria
    public int Dia { get; set; }
    public int Mes { get; set; }
    public int Año { get; set; }

    public Fecha(DateTime dateTime)
    {
        Dia = dateTime.Day;
        Mes = dateTime.Month;
        Año = dateTime.Year;
    }
}