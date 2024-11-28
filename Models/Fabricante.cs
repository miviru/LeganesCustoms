
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Fabricante
{
    public long Id { get; set; } // Clave primaria
    public long Id_grupo { get; set; } // Clave foránea
    public string Nombre { get; set; } = string.Empty;
    public int Año_fundacion { get; set; }
    public Pais Pais { get; set; }
    public required Grupo Grupo { get; set; }

    // Relacion 1:N con vehiculo
    public required List<Vehiculo> Vehiculos { get; set; } = new();

    public Fabricante()
    {
        Grupo = new Grupo
        {
            Fabricantes = new List<Fabricante>()
        };
        Vehiculos = new List<Vehiculo>();
    }
}