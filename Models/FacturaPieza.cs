namespace LeganesCustomsBlazor.Models;

public class FacturaPieza
{
    public long Id_factura { get; set; } // Clave foránea a Factura
    public Factura Factura { get; set; } = null!;

    public long Id_pieza { get; set; } // Clave foránea a Pieza
    public Pieza Pieza { get; set; } = null!;
}