using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Ciudad : BaseEntity
{
    

    public string NombreCiu { get; set; } = null!;

    public int DepId { get; set; }

    public virtual Departamento Dep { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
