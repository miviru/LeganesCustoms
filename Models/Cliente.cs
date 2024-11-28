
namespace LeganesCustomsBlazor.Models;

public class Cliente : Persona
{
    public long Id_Cliente { get; set; } // Clave primaria

    // Relacion 1:N con vehiculos
    public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    // Relacion 1:N con citas
    public List<Cita>? Citas { get; set; }

     // Relación 1:N con Factura
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

public Cliente()
{
    // Inicialización por defecto de las colecciones
    Vehiculos = new List<Vehiculo>();
    Citas = new List<Cita>();
    Facturas = new List<Factura>();
}
}