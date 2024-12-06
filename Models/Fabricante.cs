using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LeganesCustomsBlazor.Models;

public class Fabricante
{
    public long Id { get; set; } // Clave primaria

    public long? Id_grupo { get; set; } // Clave foránea opcional

    public string Nombre { get; set; } = string.Empty;

    public int? Año_fundacion { get; set; } // Hacerlo opcional para datos incompletos

    public Pais? Pais { get; set; } // Hacerlo opcional

    // Relación con Grupo
    public Grupo? Grupo { get; set; } // Hacerlo opcional para evitar problemas de serialización

    // Relación 1:N con Vehículo
    [JsonIgnore] // Ignorar esta propiedad durante la serialización
    public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    public Fabricante()
    {
        // Inicialización predeterminada opcional si Grupo no es null
        Grupo ??= new Grupo
        {
            Fabricantes = new List<Fabricante>()
        };

        Vehiculos ??= new List<Vehiculo>();
    }
}
