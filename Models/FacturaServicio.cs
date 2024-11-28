namespace LeganesCustomsBlazor.Models;

public class FacturaServicio
{
    public long Id_factura { get; set; } // Clave foránea a Factura
    public required Factura Factura { get; set; }

    public long Id_servicio { get; set; } // Clave foránea a Servicio
    public required Servicio Servicio { get; set; }
}
