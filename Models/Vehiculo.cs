
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Vehiculo
{
    public long Id { get; set; } // Clave primaria
    public long Id_fabricante { get; set; } // Clave foránea
    public required Fabricante Fabricante { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public string? Motorizacion { get; set; }
    public string? Motor { get; set; }
    public string Matricula { get; set; } = string.Empty;
    public DateTime Fecha_matriculacion { get; set; }
    public string? Color { get; set; }
    public string? FotoUrl { get; set; }
    public long Id_cliente { get; set; } // Clave foránea
    public required Cliente Cliente { get; set; }

    // Relacion 1:N con citas
    public List<Cita> Citas { get; set; } = new List<Cita>();

    // Relación 1:N con Factura
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    
public Vehiculo()
{
    Fabricante = new Fabricante
    {
        Grupo = new Grupo
        {
            Fabricantes = new List<Fabricante>() // Inicializa Fabricantes en Grupo
        },
        Vehiculos = new List<Vehiculo>() // Inicializa Vehiculos en Fabricante
    };
    Cliente = new Cliente
    {
        Vehiculos = new List<Vehiculo>() // Inicializa Vehiculos en Cliente
    };
}



}