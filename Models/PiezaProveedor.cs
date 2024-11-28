namespace LeganesCustomsBlazor.Models;

public class PiezaProveedor
{
    public long Id_pieza { get; set; } // Clave foránea a Pieza
    public Pieza Pieza { get; set; } = null!;

    public long Id_proveedor { get; set; } // Clave foránea a Proveedor
    public Proveedor Proveedor { get; set; } = null!;
}
