using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Departamento : BaseEntity
{
    

    public string NombreDep { get; set; } = null!;

    public int PaisId { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pais Pais { get; set; } = null!;
}
