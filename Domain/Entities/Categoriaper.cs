using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Categoriaper : BaseEntity
{
    public string NombreCat { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
