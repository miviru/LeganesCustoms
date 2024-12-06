
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LeganesCustomsBlazor.Models;

public class Grupo 
{
    public long Id { get; set; } // Clave primaria
    public string Nombre { get; set; } = string.Empty;
    public Pais Pais { get; set; } 

    // Relacion 1:N con fabricante
    [JsonIgnore]
    public ICollection<Fabricante> Fabricantes { get; set; } = new List<Fabricante>();
  
}