
using System;
using System.Collections.Generic;

namespace LeganesCustomsBlazor.Models;

public class Vehiculo
{
    public long Id { get; set; } // Clave primaria
    public long Id_fabricante { get; set; } // Clave foránea
    public required Fabricante Fabricante { get; set; }
    public string? Modelo { get; set; }
    public string? Motorizacion { get; set; }
    public string? Motor { get; set; }
    public string? Matricula { get; set; }
    public DateTime Fecha_matriculacion { get; set; }
    public int Color { get; set; }
    public long Id_cliente { get; set; } // Clave foránea
    public required Cliente Cliente { get; set; }

    // Relacion 1:N con citas
    public required List<Cita> Citas { get; set; }

    public Vehiculo(long id, long idFabricante, Fabricante fabricante, string modelo, 
                        string motorizacion, string motor, string matricula, 
                        DateTime fechaMatriculacion, int color, long idCliente, Cliente cliente)
        {
            Id = id;
            Id_fabricante = idFabricante;
            Fabricante = fabricante;
            Modelo = modelo;
            Motorizacion = motorizacion;
            Motor = motor;
            Matricula = matricula;
            Fecha_matriculacion = fechaMatriculacion;
            Color = color;
            Id_cliente = idCliente;
            Cliente = cliente;
            Citas = new List<Cita>(); // Inicializamos la lista de citas
        }
}